using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlogApp.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private readonly SignInManager<IdentityUser> _signinManager;
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private IConfiguration _configuration;

        public UserServices(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signinManager, ApplicationDbContext context, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            _signinManager = signinManager;
        }

        public async Task<UserManagerResponse> CreateAdminAsync(AdminDto model)
        {
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.name,
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "Admin");
            }

            return new UserManagerResponse
            {
                Message = "The admin cannot be created",
                IsSuccess = false,

            };

        }

        public async Task<UserManagerResponse> DeleteUserAsync(string email)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user == null)
                {
                    return new UserManagerResponse
                    {
                        Message = "User not found",
                        IsSuccess = false
                    };
                }

                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return new UserManagerResponse
                    {
                        Message = "User deleted successfully",
                        IsSuccess = true
                    };
                }

                return new UserManagerResponse
                {
                    Message = "Failed to delete user",
                    IsSuccess = false,
                    Errors = result.Errors.Select(e => e.Description)
                };
            }
            catch (Exception ex)
            {
                // Log exception
                return new UserManagerResponse
                {
                    Message = "An error occurred while deleting the user",
                    IsSuccess = false,
                    Errors = new[] { ex.Message }
                };
            }
        }


        public async Task<IEnumerable<IdentityUser>> GetAllAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        public async Task<IdentityUser> GetUserAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<UserStatsDto> GetUserRegistrationStatsAsync()
        {
            var today = DateTime.UtcNow;
            var weekAgo = today.AddDays(-7);
            var monthAgo = today.AddMonths(-1);
            var yearAgo = today.AddYears(-1);

            var weeklyCount = await _context.Users.CountAsync(u => u.RegisteredAt >= weekAgo);
            var monthlyCount = await _context.Users.CountAsync(u => u.RegisteredAt >= monthAgo);
            var yearlyCount = await _context.Users.CountAsync(u => u.RegisteredAt >= yearAgo);

            return new UserStatsDto
            {
                WeeklyCount = weeklyCount,
                MonthlyCount= monthlyCount,
                YearlyCount = yearlyCount
            };
        }

        public async Task<UserManagerResponse> LoginUserAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "There is no user with this email address!!",
                    IsSuccess = false,
                };
            }

            var result = await _userManager.CheckPasswordAsync(user, model.Password);

            if (!result)
            {
                return new UserManagerResponse
                {
                    Message = "Invalid Password",
                    IsSuccess = false,
                };
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {

                new Claim("Email", model.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Id),


            };

            foreach (var role in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.Now.AddDays(30),
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
                );

            string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

            return new UserManagerResponse
            {
                Message = tokenAsString,
                IsSuccess = true,
                ExpireDate = token.ValidTo,
                Roles = userRoles.ToList(),
                Name = user.UserName,
                Id = user.Id,

            };
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterDto model)
        {
            if (model == null)
            {
                throw new NullReferenceException("Register Model is null");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return new UserManagerResponse
                {
                    Message = "The passwords did not match. Please confirm your password.",
                    IsSuccess = false,
                };
            }

            var existingUser = await _userManager.FindByEmailAsync(model.Email);
            if (existingUser != null)
            {
                return new UserManagerResponse
                {
                    Message = "An account with this email already exists.",
                    IsSuccess = false,
                };
            }

            var identityUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Name,
                //RegisteredAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(identityUser, model.Password);

            if (result.Succeeded)
            {
                var user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password, // Store hashed password if needed
                    RegisteredAt = DateTime.UtcNow // Store the current time as registration date
                };

                // Save the User to the database (you will need to implement this logic)
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var roleResult = await _userManager.AddToRoleAsync(identityUser, "User");
                if (roleResult.Succeeded)
                {
                    return new UserManagerResponse
                    {
                        Message = "User Registration Succeeded.",
                        IsSuccess = true,
                    };
                }
                else
                {
                    return new UserManagerResponse
                    {
                        Message = "Role assignment failed",
                        IsSuccess = false,
                        Errors = roleResult.Errors.Select(e => e.Description)
                    };
                }
            }

            return new UserManagerResponse
            {
                Message = "User Registration Unsuccessful",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };
        }


        public async Task<UserManagerResponse> UpdateUserAsync(UpdateDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model), "Update model cannot be null");
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return new UserManagerResponse
                {
                    Message = "User not found",
                    IsSuccess = false,
                };
            }

            if (!string.IsNullOrEmpty(model.Email))
            {
                user.Email = model.Email;
                user.UserName = model.Email; // Assuming username is the same as email
            }

            if (!string.IsNullOrEmpty(model.Name))
            {
                user.UserName = model.Name;
            }



            var updateResult = await _userManager.UpdateAsync(user);

            if (updateResult.Succeeded)
            {
                return new UserManagerResponse
                {
                    Message = "User update succeeded.",
                    IsSuccess = true,
                };
            }

            return new UserManagerResponse
            {
                Message = "User update unsuccessful",
                IsSuccess = false,
                Errors = updateResult.Errors.Select(e => e.Description)
            };
        }





    }
}

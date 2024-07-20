using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Services.Implementation
{
    public class UserServices : IUserServices
    {
        private UserManager<IdentityUser> _userManager;
        public UserServices(UserManager<IdentityUser> userManager)
        {
           _userManager = userManager;
        }
        public async Task<RegisterResponse> RegisterUserAsync(RegisterDto model)
        {
           if(model == null)
            {
                throw new NullReferenceException("Register Model is null");
            }


            if (model.Password != model.ConfirmPassword)
            {
                return new RegisterResponse
                {
                    Message = "The passwords did not match. Please confirm your password.",
                    IsSuccess = false,
                };
            }

            var identityUser = new IdentityUser {
                Email = model.Email,
                UserName = model.Email,
            };

            var result = await _userManager.CreateAsync(identityUser,model.Password);

            if (result.Succeeded)
            {
                return new RegisterResponse
                {
                    Message = "User Registration Succeeded.",
                    IsSuccess = true,
                };

            }

            return new RegisterResponse
            {
                Message = "User Registration Unsuccessful",
                IsSuccess = false,
                Errors = result.Errors.Select(e => e.Description)
            };

        }
    }

}

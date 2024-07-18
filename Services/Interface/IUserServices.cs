using BlogApp.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Services.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string userId);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<IdentityResult> DeleteUserAsync(string userId);
        Task<IdentityResult> AssignAdminRoleAsync(string userId);
        Task<IdentityResult> RemoveAdminRoleAsync(string userId);
    }
}

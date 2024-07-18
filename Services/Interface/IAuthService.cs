using BlogApp.Model.Domain;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Services.Interface
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string email, string password);
        Task<IdentityResult> RegisterUserAsync(ApplicationUser user, string password);
    }
}

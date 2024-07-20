using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using Microsoft.AspNetCore.Identity;

namespace BlogApp.Services.Interface
{
    public interface IUserServices
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterDto model);
        Task<UserManagerResponse> LoginUserAsync(LoginDto model);
    }
}

using BlogApp.Model.Domain;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userService;

        public UsersController(IUserServices userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] ApplicationUser user)
        {
            if (id != user.Id)
                return BadRequest();

            var result = await _userService.UpdateUserAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _userService.DeleteUserAsync(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("{id}/assign-admin")]
        public async Task<IActionResult> AssignAdminRole(string id)
        {
            var result = await _userService.AssignAdminRoleAsync(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpPost("{id}/remove-admin")]
        public async Task<IActionResult> RemoveAdminRole(string id)
        {
            var result = await _userService.RemoveAdminRoleAsync(id);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }
    }

}

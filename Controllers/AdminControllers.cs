using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminControllers : ControllerBase
    {
        private readonly IUserServices _userService;

        public AdminControllers(IUserServices userServices)
        {
            _userService = userServices;
        }


      //  [Authorize(Roles = "SuperAdmin")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult>AddAdmin([FromBody] AdminDto adminDto)
        {
            if (adminDto == null)
            {
                return BadRequest();
            }
            var admin = await _userService.CreateAdminAsync(adminDto);
            if (admin.IsSuccess)
            {
                return Ok(admin);

            }
            return BadRequest(admin.Errors);
        }
    }
}

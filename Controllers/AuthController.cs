using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IUserServices _userService;

        public AuthController(IUserServices userService)
        {
            _userService = userService;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.RegisterUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);//status code 200;

                }
                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid in user register.");//status code 400
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginUserAsync([FromBody] LoginDto model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userService.LoginUserAsync(model);

                if (result.IsSuccess)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest("Some properties are not valid");
        }

       
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetUserAsync([FromQuery] string email)
        {
            var user = await _userService.GetUserAsync(email);

            if(user == null)
            {
                return NotFound(new { message = "User is not found" });
            }

            return Ok(user); 
        }

        
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var users = await _userService.GetAllAsync();
            
            if(users == null)
            {
                return NotFound(new { message = "Users are empty" });
            }

            return Ok(users);
        }

        [HttpPut]
        [Route("Update")]

        public async Task<IActionResult> UpdateUserAsync([FromBody] UpdateDto model)
        {
            if(model == null)
            {
                return BadRequest("Update model is null");
            }

            var response = await _userService.UpdateUserAsync(model);

            if(response .IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);    
        }


        
        [HttpDelete]
        [Route("Delete/{email}")]
        public async Task<IActionResult> DeleteUserAsync(string email)
        {
            var response = await _userService.DeleteUserAsync(email);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
    }

}

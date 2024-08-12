using BlogApp.Model.Dto;
using BlogApp.Services.Implementation;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServices _blogServices;
        private readonly IUserServices _userServices;
        private readonly IImageService _imageService;

        public BlogController(IBlogServices blogServices, IUserServices userServices, IImageService imageService)
        {
            _blogServices = blogServices;
            _userServices = userServices;
            _imageService = imageService;
        }


        [HttpPost]
        [Route("AddBlogPost")]
        public async Task<IActionResult> AddBlogPost([FromForm] BlogPostDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

          

            try
            {
               
                    List<int> tagIds = model.TagIds ?? new List<int>();
                
                var postResponse = await _blogServices.AddAsync(model);

                if (postResponse.IsSuccess)
                {
                    return Ok(postResponse);
                }

                return BadRequest(postResponse); // Provide more detail on failure
            }
            catch (Exception ex)
            {
                // Log exception details (consider using a logging framework)
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        [HttpGet]
        [Route("GetAllBlog")]
        public async Task<IActionResult> GetAllBlog()
        {
            var blogs =  await _blogServices.GetAllAsync();
            if(blogs != null)
            {
                return Ok(blogs);   
            }

            return BadRequest("No blogs found");
        }

        [HttpDelete]
        [Route("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var response = await _blogServices.DeleteAsync(id);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest();
        }


        [HttpPost]
        [Route("UploadImage")]
        public async Task<IActionResult> UploadImage([FromForm] IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("No image file provided");
            }

            var imagePath = await _imageService.UploadImageAsync(image);

            if (!string.IsNullOrEmpty(imagePath))
            {
                return Ok(new { path = imagePath });
            }

            return BadRequest("Image upload failed");
        }




        [HttpPut]
        [Route("UpdateBlogImage/{id}")]
        public async Task<IActionResult> UpdateBlogImage(int id, [FromForm] IFormFile image)
        {
            if(image == null)
            {
                return BadRequest("No image file provided");
            }

            var response = await _blogServices.UpdateImageAsync(image, id);
            if(response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }


    }
}

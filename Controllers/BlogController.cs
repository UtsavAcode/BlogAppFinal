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
        public async Task<IActionResult> AddBlogPost([FromForm] BlogPostDto model, [FromForm] IFormFile? image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Some properties are not valid while creating the blog.");
            }

            var authorId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(authorId))
            {
                return Unauthorized();
            }

            // Handle image upload
            if (image != null && image.Length > 0)
            {
                var imagePath = await _imageService.UploadImageAsync(image);
                model.FeaturedImagePath = imagePath;
            }

            var response = await _blogServices.AddAsync(model, image, authorId);

            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return BadRequest(response);
        }


    }
}

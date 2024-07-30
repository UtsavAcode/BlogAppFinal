using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogServices _blogServices;

        public BlogController(IBlogServices blogServices)
        {
            _blogServices = blogServices;
        }

        [HttpPost]
        [Route("AddBlog")]
        public async Task <IActionResult> AddBlogPost([FromForm ] BlogPostDto blogPost)
        {
            var result = await _blogServices.AddAsync(blogPost);
            if(result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}

using BlogApp.Data;
using BlogApp.Model.Domain;
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
        private readonly BlogDbContext _context;

        public BlogController(IBlogServices blogServices, IUserServices userServices, IImageService imageService, BlogDbContext context)
        {
            _blogServices = blogServices;
            _userServices = userServices;
            _imageService = imageService;
            _context = context;
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
            var blogs = await _blogServices.GetAllAsync();
            if (blogs != null)
            {
                return Ok(blogs);
            }

            return BadRequest("No blogs found");
        }

        [HttpGet]
        [Route("GetBlog/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogServices.GetAsync(id);
            if (blog != null)
            {
                return Ok(blog);
            }
            return BadRequest("No Blog");

        }

        [HttpDelete]
        [Route("DeleteBlog/{id}")]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var response = await _blogServices.DeleteAsync(id);
            if (response.IsSuccess)
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
        [Route("UpdateBlogPost")]
        public async Task<IActionResult> UpdateBlogPost([FromForm] UpdateBlogPostDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var response = await _blogServices.UpdateAsync(model);

                if (response.IsSuccess)
                {
                    return Ok(response);
                }

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }




        [HttpPut]
        [Route("UpdateBlogImage/{id}")]
        public async Task<IActionResult> UpdateBlogImage(int id, [FromForm] IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("No image file provided");
            }

            var response = await _blogServices.UpdateImageAsync(image, id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        private string GetUserId()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim))
            {
                throw new UnauthorizedAccessException("User ID not found in token.");
            }
            return userIdClaim; // Return as a string
        }



        [HttpPost("{blogPostId}/like")]
        public async Task<IActionResult> LikeBlogPost(int blogPostId)
        {
            var userId = GetUserId(); // Get user ID from claims

            // Check if the user already liked the blog post
            var hasLiked = await _blogServices.CheckIfUserLiked(blogPostId, userId);

            if (hasLiked)
            {
                // Remove like
                var removed = await _blogServices.RemoveLike(blogPostId, userId);
                if (removed)
                {
                    return Ok(new { isSuccess = true, message = "Like removed." });
                }
                return BadRequest("Error removing like.");
            }
            else
            {
                // Add like
                var liked = await _blogServices.AddLikeAsync(blogPostId, userId);
                if (liked)
                {
                    return Ok(new { isSuccess = true, message = "Blog liked." });
                }
                return BadRequest("Error liking blog.");
            }
        }


        [HttpGet("{blogPostId}/likesCount")]
        public async Task<IActionResult> GetLikesCount(int blogPostId)
        {
            var count = await _blogServices.GetLikesCountAsync(blogPostId);
            return Ok(new { LikesCount = count });
        }







        [HttpDelete("{blogPostId}/like")]
        public async Task<IActionResult> RemoveLike(int blogPostId)
        {
            var userId = GetUserId(); // Get user ID from claims

            // Attempt to remove the like
            var removed = await _blogServices.RemoveLike(blogPostId, userId);
            if (removed)
            {
                return Ok(new { isSuccess = true, message = "Like removed." });
            }
            return BadRequest("Error removing like.");
        }

        [HttpGet("{blogPostId}/hasLiked")]
        public async Task<IActionResult> HasUserLikedBlogPost(int blogPostId)
        {
            var userId = GetUserId(); // Get user ID from claims

            var hasLiked = await _blogServices.CheckIfUserLiked(blogPostId, userId);
            return Ok(new { hasLiked });
        }


        [HttpPost("{blogId}/comments")]
        public async Task<IActionResult> AddComment(int blogId, [FromBody] AddCommentDto commentDto)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var comment = await _blogServices.AddCommentAsync(blogId, userId, commentDto);

            if (comment != null)
            {
                return Ok(new { isSuccess = true, comment });
            }

            return BadRequest("Failed to add comment.");
        }
        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetComments(int blogId)
        {
            var comments = await _blogServices.GetCommentsByBlogPostIdAsync(blogId);
            return Ok(comments);
        }

        [HttpPut]
        [Route("updateComment")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto comment)
        {
            if (comment == null)
            {
                return BadRequest();
            }
            var response = await _blogServices.UpdateCommentAsync(comment);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete]
        [Route("Delete/{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var response = await _blogServices.DeleteCommentAsync(commentId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpGet]
        [Route("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _blogServices.GetCommentsAsync();
            if (comments == null)
            {
                return BadRequest("No comments");
            }
            return Ok(comments);
        }

        [HttpGet]
        [Route("GetViews/{blogPostId}")]
        public async Task<IActionResult> GetViews(int blogPostId)
        {
            var views = await _blogServices.GetBlogViewDetailsAsync(blogPostId);

            if (views == null)
            {
                return BadRequest("No views");
            }

            return Ok(views);
        }



        [HttpPost("{blogPostId}/registerView")]
        public async Task<IActionResult> RegisterView(int blogPostId)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
                var userAgent = Request.Headers["User-Agent"].ToString();

                var response = await _blogServices.AddViewAsync(blogPostId, userId, ipAddress, userAgent);

                if (response.IsSuccess)
                {
                    return Ok(new { isSuccess = true, message = response.Message });
                }

                return BadRequest(new { isSuccess = false, message = response.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



        [HttpGet]
        [Route("GetAllViews")]
        public async Task<ActionResult<IEnumerable<BlogView>>> GetAllViews([FromQuery] List<int> blogPostIds)
        {
            if (blogPostIds == null || !blogPostIds.Any())
            {
                return BadRequest("No blog post IDs provided.");
            }

            var views = await _blogServices.GetAllViewsAsync(blogPostIds);

            if (views == null || !views.Any())
            {
                return NotFound("No views found for the provided blog post IDs.");
            }

            return Ok(views);
        }

        [HttpGet("ReadingData/{blogPostId}")]
        public async Task<IActionResult> GetReadingData(int blogPostId)
        {
            var data = await _blogServices.GetReadingDataAsync(blogPostId);
            if (data != null)
            {
                return Ok(data);
            }
            else return BadRequest();
        }



        [HttpPost("Send")]
        public async Task<IActionResult> Send([FromBody] ReadingDataDto readingData)
        {
            if (readingData == null)
            {
                return BadRequest("Reading data is required.");
            }

            await _blogServices.SaveReadingDataAsync(readingData);
            return Ok(new { message = "Reading data saved successfully." });
        }



        [HttpGet("{blogPostId}/average")]
        public async Task<IActionResult> GetAverageScrollPositionAndReadingTime(int blogPostId)
        {
            var result = await _blogServices.GetAverageScrollPositionAndReadingTimeAsync(blogPostId);

            if (result.averageScrollPosition.HasValue || result.averageReadingTime.HasValue)
            {
                return Ok(new
                {
                    AverageScrollPosition = result.averageScrollPosition,
                    AverageReadingTime = result.averageReadingTime
                });
            }

            return NotFound("No data found for the specified blog post.");
        }


        [HttpPut("ConfirmBlog/{id}")]
        public async Task<IActionResult> ConfirmBlog(int id, [FromBody] BlogConfirmationDto confirmationDto)
        {
            try
            {
                if (confirmationDto == null)
                {
                    return BadRequest("Confirmation data is required.");
                }

                var blogPost = await _context.BlogPosts.FindAsync(id);
                if (blogPost == null)
                {
                    return NotFound($"Blog post with ID {id} not found.");
                }

                blogPost.IsConfirmed = confirmationDto.IsConfirmed;
                _context.BlogPosts.Update(blogPost);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    message = "Blog post confirmation status updated successfully.",
                    isConfirmed = blogPost.IsConfirmed
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while updating the blog confirmation status.");
            }
        }

    }
}

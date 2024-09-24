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

        [HttpGet]
        [Route("GetBlog/{id}")]
        public async Task<IActionResult> GetBlog(int id)
        {
            var blog = await _blogServices.GetAsync(id);
            if(blog != null)    
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
            var userName = User.FindFirstValue(ClaimTypes.Name);

            var comment = await _blogServices.AddCommentAsync(blogId, userId,userName, commentDto);

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

        [HttpPut("{commentId}")]
        public async Task<IActionResult> UpdateComment(int commentId, [FromBody] string newContent)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var updatedComment = await _blogServices.UpdateCommentAsync(commentId, newContent, userId);

            if (updatedComment != null)
            {
                return Ok(new { isSuccess = true, comment = updatedComment });
            }

            return BadRequest("Failed to update comment.");
        }

        [HttpDelete("{commentId}")]
        public async Task<IActionResult> DeleteComment(int commentId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var success = await _blogServices.DeleteCommentAsync(commentId, userId);

            if (success)
            {
                return Ok(new { isSuccess = true });
            }

            return BadRequest("Failed to delete comment.");
        }

        [HttpGet]
        [Route("GetComments")]
        public async Task<IActionResult> GetComments()
        {
            var comments = await _blogServices.GetCommentsAsync();
            if(comments == null)
            {
                return BadRequest("No comments");
            }
            return Ok(comments);
        }


    }
}

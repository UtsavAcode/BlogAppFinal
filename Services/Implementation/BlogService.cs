using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace BlogApp.Services.Implementation
{
    public class BlogService : IBlogServices
    {
        private readonly BlogDbContext _context;
        private readonly IImageService _imageService;

        public BlogService(BlogDbContext context, IImageService imageService)
        {
            _context = context;
            _imageService = imageService;
        }

        public async Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost, IFormFile? image, string authorId)
        {
            if (blogPost == null)
            {
                return new BlogManagerResponse
                {
                    Message = "The Blog Post is null",
                    IsSuccess = false,
                };
            }

            try
            {
                // Handle image upload
                string? imagePath = null;
                if (image != null && image.Length > 0)
                {
                    imagePath = await _imageService.UploadImageAsync(image);
                }

                var newblogPost = new BlogPost
                {
                    Title = blogPost.Title,
                    Slug = blogPost.Slug,
                    MetaDescription = blogPost.MetaDescription,
                    Keywords = blogPost.Keywords,
                    Content = blogPost.Content,
                    Categories = blogPost.Categories,
                    FeaturedImagePath = imagePath, // Save the image path
                    AuthorId = authorId,
                    Visible = blogPost.Visible,
                    CreatedAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Tags = await _context.Tags.Where(t => blogPost.TagIds.Contains(t.Id)).ToListAsync()
                };

                await _context.BlogPosts.AddAsync(newblogPost);
                await _context.SaveChangesAsync();

                return new BlogManagerResponse
                {
                    Message = "New Blog Post added",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new BlogManagerResponse
                {
                    Message = $"Failed to add the blog post: {ex.Message}",
                    IsSuccess = false
                };
            }
        }


        public Task<BlogManagerResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPost?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogManagerResponse> UpdateAsync(UpdateBlogPostDto blogPost)
        {
            throw new NotImplementedException();
        }

        public Task<BlogManagerResponse> UpdateImageAsync(IFormFile image, int blogPostId)
        {
            throw new NotImplementedException();
        }
    }
}

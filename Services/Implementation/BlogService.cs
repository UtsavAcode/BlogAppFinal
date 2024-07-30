using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Http;
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

        public async Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost)
        {
            if (blogPost == null)
            {
                return new BlogManagerResponse
                {
                    Message = "Blog post data is missing.",
                    IsSuccess = false,
                };
            }

            try
            {
                var blog = new BlogPost
                {
                    Title = blogPost.Title,
                    Slug = blogPost.Slug,
                    MetaDescription = blogPost.MetaDescription,
                    Keywords = blogPost.Keywords,
                    Content = blogPost.Content,
                    Categories = blogPost.Categories,
                    AltText = blogPost.AltText,
                    AuthorId = blogPost.AuthorId,
                    Visible = blogPost.Visible,
                    CreatedAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };

                if (blogPost.FeaturedImage != null)
                {
                    blog.FeaturedImagePath = await _imageService.UploadImageAsync(blogPost.FeaturedImage);
                }

                _context.BlogPosts.Add(blog);
                await _context.SaveChangesAsync();

                return new BlogManagerResponse
                {
                    Message = "Blog post added successfully.",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                return new BlogManagerResponse
                {
                    Message = $"Failed to add blog post: {ex.Message}",
                    IsSuccess = false,
                };
            }
        }

        public Task<BlogManagerResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BlogPostDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<BlogPostDto?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogManagerResponse> UpdateAsync(BlogPostDto blogPost)
        {
            throw new NotImplementedException();
        }

        // Other methods (DeleteAsync, GetAllAsync, GetAsync, UpdateAsync)
    }
}

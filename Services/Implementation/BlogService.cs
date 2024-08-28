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

        public async Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost)
        {
            if (blogPost == null)
            {
                return new BlogManagerResponse
                {

                    Message = "The dto data is null",
                    IsSuccess = false,

                };

            }

            try
            {
                string imagePath = null;
                if(blogPost.Image != null)
                {
                    imagePath = await _imageService.UploadImageAsync(blogPost.Image);
                }


                List<Tag> tags = new List<Tag>();

                // Check if TagIds is not null or empty before querying the database
                if (blogPost.TagIds != null && blogPost.TagIds.Any())
                {
                    tags = await _context.Tags
                        .Where(t => blogPost.TagIds.Contains(t.Id))
                        .ToListAsync();
                }

                var post = new BlogPost
                {
                    Title = blogPost.Title,
                    MetaDescription = blogPost.MetaDescription,
                    Content = blogPost.Content,
                    CreatedAt = DateTime.UtcNow,
                    AuthorId = blogPost.AuthorId,
                    AuthorName = blogPost.AuthorName,
                    FeaturedImagePath = imagePath,
                    Tags = tags,
                };

                await _context.BlogPosts.AddAsync(post);
                await _context.SaveChangesAsync();

                return new BlogManagerResponse
                {
                    Message = "Post added",
                    IsSuccess = true,
                };
            }

            catch (Exception ex)
            {
                return new BlogManagerResponse
                {
                    Message = ex.Message,
                    IsSuccess = false,
                };

            }


        }

        


        public async Task<BlogManagerResponse> DeleteAsync(int id)
        {
            var post = await _context.BlogPosts.FindAsync(id);
            if (post != null)
            {
                if(!string.IsNullOrEmpty(post.FeaturedImagePath))
                {
                    await _imageService.DeleteImageAsync(post.FeaturedImagePath);
                }

                _context.Remove(post);
                await _context.SaveChangesAsync();

                return new BlogManagerResponse
                {
                    Message = "Post Deleted Successfully",
                    IsSuccess = true,
                };
            }
            return new BlogManagerResponse
            {
                Message = "Failed to delete the post",
                IsSuccess = false,
            };
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _context.BlogPosts
          .Include(bp => bp.Tags) // Ensure tags are included
          .ToListAsync();
        }

        public async Task<BlogPost?> GetAsync(int id) { 
         return await _context.BlogPosts
        .Include(bp => bp.Tags) // Ensure tags are included
        .FirstOrDefaultAsync(bp => bp.Id == id);
    }

        public async Task<BlogManagerResponse> UpdateAsync(UpdateBlogPostDto blogPost)
        {
            var post = await _context.BlogPosts
                .Include(bp => bp.Tags)
                .FirstOrDefaultAsync(bp => bp.Id == blogPost.Id);

            if (post == null)
            {
                return new BlogManagerResponse
                {
                    Message = "Blog post not found",
                    IsSuccess = false,
                };
            }

            post.Title = blogPost.Title;
            post.MetaDescription = blogPost.MetaDescription;
            post.Content = blogPost.Content;

            if (blogPost.Image != null)
            {
                post.FeaturedImagePath = await _imageService.UpdateImageAsync(blogPost.Image, post.FeaturedImagePath);
            }

            // If tagIds are provided, update the tags
            if (blogPost.TagIds != null && blogPost.TagIds.Any())
            {
                var currentTagIds = post.Tags.Select(t => t.Id).ToList();
                var newTagIds = blogPost.TagIds;

                // Tags to remove (those present in current tags but not in the new tags)
                var tagsToRemove = post.Tags.Where(t => !newTagIds.Contains(t.Id)).ToList();
                foreach (var tag in tagsToRemove)
                {
                    post.Tags.Remove(tag);
                }

                // Tags to add (those present in new tags but not in current tags)
                var tagsToAdd = await _context.Tags
                    .Where(t => newTagIds.Contains(t.Id) && !currentTagIds.Contains(t.Id))
                    .ToListAsync();
                foreach (var tag in tagsToAdd)
                {
                    post.Tags.Add(tag);
                }
            }

            _context.BlogPosts.Update(post);
            await _context.SaveChangesAsync();

            return new BlogManagerResponse
            {
                Message = "Blog post updated successfully",
                IsSuccess = true,
            };
        }


        public async Task<BlogManagerResponse> UpdateImageAsync(IFormFile image, int blogPostId)
        {
            var post = await _context.BlogPosts.FindAsync(blogPostId);
            if (post == null)
            {
                return new BlogManagerResponse
                {
                    Message = "Blog post not found",
                    IsSuccess = false,
                };
            }

            string imagePath = await _imageService.UpdateImageAsync(image, post.FeaturedImagePath);
            post.FeaturedImagePath = imagePath;

            _context.BlogPosts.Update(post);
            await _context.SaveChangesAsync();

            return new BlogManagerResponse
            {
                Message = "Image updated successfully",
                IsSuccess = true,
            };
        }
    }
}
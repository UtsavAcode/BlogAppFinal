using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;

namespace BlogApp.Services.Implementation
{
    public class BlogService : IBlogServices
    {
        private readonly BlogDbContext _context;

        public BlogService(BlogDbContext context)
        {
            _context = context;
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
                    FeaturedImage = blogPost.FeaturedImage,
                    AltText = blogPost.AltText,
                    AuthorId = blogPost.AuthorId,
                    Visible = blogPost.Visible,
                    
                    CreatedAt = DateTime.UtcNow, // Assuming you have CreatedAt property in BlogPost model
                    UpdateAt = DateTime.UtcNow  // Assuming you have UpdatedAt property in BlogPost model
                };

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
    }

    

    



    }


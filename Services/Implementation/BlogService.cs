using BlogApp.Migrations.BlogDb;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;

namespace BlogApp.Services.Implementation
{
    public class BlogService : IBlogServices
    {
        private readonly ApplicationDbContext _context;

        public BlogService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost)
        {
            if(blogPost == null)
            {
                return new BlogManagerResponse
                {
                    Message = "Tag data is missing.",
                    IsSuccess = false,
                };
            }

            try
            {
                var blog = new BlogPost
                {
                    PageTitle = blogPost.Title,
                }
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

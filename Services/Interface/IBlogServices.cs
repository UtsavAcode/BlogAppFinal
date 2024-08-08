
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface IBlogServices
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();
        Task<BlogPost?> GetAsync(int id);
      //  Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost, IFormFile? image, string authorId);
        Task<BlogManagerResponse> UpdateAsync(UpdateBlogPostDto blogPost);
        Task<BlogManagerResponse> DeleteAsync(int id);
        Task<BlogManagerResponse> UpdateImageAsync(IFormFile image, int blogPostId);
    }
}

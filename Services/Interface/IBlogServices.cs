
using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface IBlogServices
    {
        Task<IEnumerable<BlogPostDto>> GetAllAsync();
        Task<BlogPostDto?> GetAsync(int id);
      //  Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost);
        Task<BlogManagerResponse> UpdateAsync(BlogPostDto blogPost);
        Task<BlogManagerResponse> DeleteAsync(int id);
    }
}

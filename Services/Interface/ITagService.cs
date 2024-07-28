using BlogApp.Model.Domain;
using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task<Tag> GetAsync(int id);
        Task<BlogManagerResponse> AddAsync(AddTagDto tag);
        Task<BlogManagerResponse> UpdateAsync(UpdateTagDto tag);
        Task<BlogManagerResponse> DeleteAsync(int id);
    }
}

using BlogApp.Model.Domain;
using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface ITagService
    {
        Task<IEnumerable<Tag>> GetAllAsync();
        Task GetAsync(Guid id);
        Task<BlogManagerResponse> AddAsync(AddTagDto tag);
        Task<BlogManagerResponse> UpdateAsync(Tag tag);
        Task<BlogManagerResponse> DeleteAsync(Guid id);
    }
}

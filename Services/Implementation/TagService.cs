using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;

namespace BlogApp.Services.Implementation
{
    public class TagService : ITagService
    {
        private readonly BlogDbContext _context;

        public TagService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<BlogManagerResponse> AddAsync(AddTagDto tagDto)
        {
            if (tagDto == null)
            {
                return new BlogManagerResponse
                {
                    Message = "Tag data is missing.",
                    IsSuccess = false,
                };
            }

            try
            {
                // Convert AddTagDto to Tag entity
                var tag = new Tag
                {
                    Name = tagDto.Name // Assuming Tag entity has a Name property
                };

                await _context.Tags.AddAsync(tag);
                await _context.SaveChangesAsync();

                return new BlogManagerResponse
                {
                    Message = "New Tag Added",
                    IsSuccess = true,
                };
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                // _logger.LogError(ex, "Error adding new tag");

                return new BlogManagerResponse
                {
                    Message = $"Failed to add tag: {ex.Message}",
                    IsSuccess = false,
                };
            }
        }

        public Task<BlogManagerResponse> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tag>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<BlogManagerResponse> UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}

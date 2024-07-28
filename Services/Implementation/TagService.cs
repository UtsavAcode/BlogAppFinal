using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.EntityFrameworkCore;

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

                return new BlogManagerResponse
                {
                    Message = $"Failed to add tag: {ex.Message}",
                    IsSuccess = false,
                };
            }
        }

        public async Task<BlogManagerResponse> DeleteAsync(int id)
        {
            var tag = await _context.Tags.FindAsync(id);

            if(tag != null)
            {
                 _context.Tags.Remove(tag);
                await _context.SaveChangesAsync();
                return new BlogManagerResponse
                {
                    Message = "Tag Deleted",
                    IsSuccess = true,
                };
            }
            return new BlogManagerResponse
            {
                Message = "No Such Tag Found",
                IsSuccess = false,
            };
        }

        public async Task<IEnumerable<Tag>> GetAllAsync()
        {
            return await _context.Tags.ToListAsync();
        }

        public Task GetAsync(int id)
        {
            
        }

        public Task<BlogManagerResponse> UpdateAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}

using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface IImageService
    {
      Task<string> UploadImageAsync(IFormFile image);
        Task<string> UpdateImageAsync(IFormFile image, string existingImagepath);
        Task DeleteImageAsync(string imagePath);
    }
}

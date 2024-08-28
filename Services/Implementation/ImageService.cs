using BlogApp.Model.Dto;
using BlogApp.Services.Interface;

namespace BlogApp.Services.Implementation
{
    public class ImageService : IImageService
    {
        private readonly string _imageDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
        public ImageService()
        {
            if (!Directory.Exists(_imageDirectory))
            {
                Directory.CreateDirectory(_imageDirectory);
            }   
        }
        public async Task DeleteImageAsync(string imagePath)
        {
            if (!string.IsNullOrEmpty(imagePath))
            {
                var fullPath = Path.Combine(_imageDirectory, imagePath.TrimStart('/'));
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
            }
        }


        public async Task<string> UpdateImageAsync(IFormFile image, string existingImagePath)
        {
            try
            {
                // Delete existing image if path is not null or empty
                if (!string.IsNullOrEmpty(existingImagePath))
                {
                    var fullPath = Path.Combine(_imageDirectory, existingImagePath.TrimStart('/'));
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                }

                // Upload the new image
                return await UploadImageAsync(image);
            }
            catch (Exception ex)
            {
                // Log the error or handle it as needed
                throw new Exception("An error occurred while updating the image.", ex);
            }
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
           if(image == null || image.Length == 0)
            {
                return null;
            }

           var filePath = Path.Combine(_imageDirectory, image.FileName);
            using(var stream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }

            return $"/images/{image.FileName}";
        }

      
    }
}

using BlogApp.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model.Dto
{
    public class BlogPostDto
    {


        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }

        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public IFormFile Image { get; set; }
        public string? Tags { get; set; }
        //  public string? Slug { get; set; }

        // [Required(ErrorMessage = "The Keywords field is required.")]
        //public string Keywords { get; set; }


        // public string? FeaturedImagePath { get; set; }

        //  public bool Visible { get; set; }
         public List<int> TagIds { get; set; }
    }
}

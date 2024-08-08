using BlogApp.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Model.Dto
{
    public class BlogPostDto
    {


        [Required(ErrorMessage = "The Title field is required.")]
        public string Title { get; set; }

        public string? Slug { get; set; }

        [Required(ErrorMessage = "The MetaDescription field is required.")]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = "The Keywords field is required.")]
        public string Keywords { get; set; }

        [Required(ErrorMessage = "The Content field is requires.")]
        public string Content { get; set; }

        public string? Categories { get; set; }
        public string? FeaturedImagePath { get; set; }

        public bool Visible { get; set; }
        public List<int>? TagIds { get; set; }
    }
}

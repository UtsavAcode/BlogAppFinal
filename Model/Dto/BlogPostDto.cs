using BlogApp.Model.Domain;

namespace BlogApp.Model.Dto
{
    public class BlogPostDto
    {
        public string PageTitle { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public string Categories { get; set; }

        public string FeaturedImage { get; set; }
        public string AltText { get; set; }
        public string AuthorId { get; set; }
        public bool Visible { get; set; }
        public DateTime PublishedDate { get; set; }

        public User Author { get; set; }
        public ICollection<Tag> Tags { get; set; }
    }
}

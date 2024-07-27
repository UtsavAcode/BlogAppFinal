using Microsoft.EntityFrameworkCore;

namespace BlogApp.Model.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }

        public string PageTitle { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public string Categories { get; set; }
    
        public string FeaturedImage { get; set; }
        public string AltText { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }
        public DateTime PublishedDate { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
        

}

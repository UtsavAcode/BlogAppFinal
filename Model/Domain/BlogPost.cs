using System.Text.Json.Serialization;

namespace BlogApp.Model.Domain
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
      
        public string MetaDescription { get; set; }
 
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public int LikeCount { get; set; }
        public string FeaturedImagePath { get; set; }

        //public bool Visible { get; set; }
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();

        //  public string Slug { get; set; }
        // public string Keywords { get; set; }
        // public DateTime UpdateAt { get; set; }
        // public ICollection<Tag> Tags { get; set; }

        public ICollection<BlogLike> Likes { get; set; }
        public ICollection<BlogComment> Comments { get; set; } = new List<BlogComment>();
    }


}

using System.Globalization;

namespace BlogApp.Model.Domain
{
    public class BlogLike
    {
            public int Id { get; set; }
            public int BlogPostId { get; set; }
            public BlogPost BlogPost { get; set; }
            public string UserId { get; set; }

            public DateTime CreatedAt { get; set; }
    }
}

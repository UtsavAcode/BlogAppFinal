namespace BlogApp.Model.Domain
{
    public class BlogComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; } // Navigation property to BlogPost
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}

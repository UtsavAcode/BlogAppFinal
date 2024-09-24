namespace BlogApp.Model.Dto
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public int BlogPostId { get; set; }
        public string BlogTitle { get; set; } // Blog post title (optional)
        public string UserId { get; set; }
    }
}

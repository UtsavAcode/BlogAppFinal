namespace BlogApp.Model.Domain
{
    public class UserBlogInteraction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int BlogPostId { get; set; }
        public bool Liked { get; set; }       // True if the user liked the blog
        public int ViewCount { get; set; }     // Number of times the user viewed the blog
        public double ReadingTime { get; set; } // Time spent reading the blog (in seconds)
        public DateTime InteractionDate { get; set; }
    }
}

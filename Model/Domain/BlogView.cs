namespace BlogApp.Model.Domain
{
    public class BlogView
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public BlogPost BlogPost { get; set; }
        public DateTime ViewAt { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
        public string IpAddress { get; set; }
        
        public string UserAgent { get; set; }// This is the device name 
    }
}

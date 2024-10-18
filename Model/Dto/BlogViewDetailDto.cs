namespace BlogApp.Model.Dto
{
    public class BlogViewDetailDto
    {
        public int BlogPostId { get; set; }
        public int TotalViews { get; set; }
      
        public DateTime ViewAt { get; set; } 

        public string UserId { get; set; }
        public string IpAddress { get; set; }

        public string UserAgent { get; set; }
    }
}

namespace BlogApp.Model.Dto
{
    public class UpdateBlogPostDto
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string MetaDescription { get; set; }
        public string Content { get; set; }
        public IFormFile? Image { get; set; } 
        public List<int>? TagIds { get; set; }
    }
}

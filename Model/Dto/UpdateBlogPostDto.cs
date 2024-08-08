namespace BlogApp.Model.Dto
{
    public class UpdateBlogPostDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Slug { get; set; }
        public string MetaDescription { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public string Categories { get; set; }
        public string FeaturedImagePath { get; set; }
        public string AltText { get; set; }
        public bool Visible { get; set; }
        public List<int> TagIds { get; set; }
    }
}

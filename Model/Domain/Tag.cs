namespace BlogApp.Model.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}

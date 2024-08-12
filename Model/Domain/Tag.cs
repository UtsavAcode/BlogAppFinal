using System.Text.Json.Serialization;

namespace BlogApp.Model.Domain
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }



        [JsonIgnore]
        public ICollection<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();
    }
}

namespace BlogApp.Model.Dto
{
    public class ReadingDataDto
    {
        public int BlogPostId { get; set; }
        public string UserId { get; set; }
        public int ReadingTime { get; set; }
        public List<float> ScrollPositions { get; set; }
    }
}

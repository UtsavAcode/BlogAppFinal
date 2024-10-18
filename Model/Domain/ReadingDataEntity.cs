namespace BlogApp.Model.Domain
{
    public class ReadingDataEntity
    {
        public int Id { get; set; }
        public int BlogPostId { get; set; }
        public string UserId { get; set; }
        public int ReadingTime { get; set; } // Store as int (seconds)
        public List<float> ScrollPositions { get; set; }
    }
}

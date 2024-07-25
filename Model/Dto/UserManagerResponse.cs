namespace BlogApp.Model.Dto
{
    public class UserManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public string Name { get; set; }
        public DateTime? ExpireDate { get; set; }
        public IList<string> Roles { get; set; }
    }
}

namespace BlogApp.Model.Dto
{
    public class RegisterResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}

﻿namespace BlogApp.Model.Dto
{
    public class BlogManagerResponse
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }

        public IEnumerable<string> Errors { get; set; }
    }
}

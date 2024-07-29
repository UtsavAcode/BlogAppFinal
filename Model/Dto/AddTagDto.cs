﻿
using BlogApp.Model.Domain;

namespace BlogApp.Model.Dto
{
    public class AddTagDto
    {
        public string Name { get; set; }

        public ICollection<BlogPost> BlogPosts { get; set; }
    }
}

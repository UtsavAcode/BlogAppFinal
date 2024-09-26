﻿
using BlogApp.Model.Domain;
using BlogApp.Model.Dto;

namespace BlogApp.Services.Interface
{
    public interface IBlogServices
    {
       Task<IEnumerable<BlogPost>> GetAllAsync();
      
        Task<BlogPost?> GetAsync(int id);
     //  Task<BlogPost?> GetByUrlHandleAsync(string urlHandle);
        Task<BlogManagerResponse> AddAsync(BlogPostDto blogPost);
        Task<BlogManagerResponse> UpdateAsync(UpdateBlogPostDto blogPost);
        Task<BlogManagerResponse> DeleteAsync(int id);
        Task<BlogManagerResponse> UpdateImageAsync(IFormFile image, int blogPostId);
        Task<bool> AddLikeAsync(int blogPostId, string userId);

        Task<BlogComment> AddCommentAsync(int blogPostId, string userId, AddCommentDto addCommentDto);
        Task<List<BlogComment>> GetCommentsByBlogPostIdAsync(int blogPostId);

        Task<IEnumerable<BlogComment>> GetCommentsAsync();
        Task<BlogManagerResponse> DeleteCommentAsync(int commentId);
        Task<BlogManagerResponse> UpdateCommentAsync(UpdateCommentDto comment);
        Task<int> GetLikesCountAsync(int blogPostId);
        Task<bool> RemoveLike(int blogPostId, string userId);
        Task<bool> CheckIfUserLiked(int blogPostId, string userId);
    }
}

using BlogApp.Model.Domain;

namespace BlogApp.Services.Interface
{
    public interface IRecommendationService
    {
        Task<List<BlogPost>> RecommendBlogsAsync(string userId, int numberOfRecommendations = 5);
    }
}

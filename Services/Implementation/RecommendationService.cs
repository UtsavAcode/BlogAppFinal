using BlogApp.Data;
using BlogApp.Model.Domain;
using BlogApp.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.Services.Implementation
{
    public class RecommendationService : IRecommendationService
    {
        private readonly BlogDbContext _context;

        public RecommendationService(BlogDbContext context)
        {
            _context = context;
        }

        public async Task<List<BlogPost>> RecommendBlogsAsync(string userId, int numberOfRecommendations = 5)
        {
            // Step 1: Get the user's viewed blogs
            var viewedBlogs = await _context.BlogViews
                .Where(bv => bv.UserId == userId)
                .Select(bv => bv.BlogPostId)
                .Distinct()
                .ToListAsync();

            if (!viewedBlogs.Any())
            {
                // No recommendations if no viewed blogs are found
                return new List<BlogPost>();
            }

            // Step 2: Get tags of the viewed blogs
            var tagsOfViewedBlogs = await _context.BlogPosts
                .Where(bp => viewedBlogs.Contains(bp.Id))
                .SelectMany(bp => bp.Tags.Select(t => t.Name)) // Assuming Tag is a navigation property in BlogPost
                .Distinct()
                .ToListAsync();

            // Step 3: Recommend blogs with the same tags, excluding the ones already viewed
            var recommendedBlogs = await _context.BlogPosts
                .Where(bp => bp.Tags.Any(t => tagsOfViewedBlogs.Contains(t.Name))
                              && !viewedBlogs.Contains(bp.Id))
                .Take(numberOfRecommendations)
                .ToListAsync();

            return recommendedBlogs;
        }
    }
}

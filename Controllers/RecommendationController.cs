using BlogApp.Services;
using BlogApp.Model.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlogApp.Services.Interface;

namespace BlogApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecommendationController : ControllerBase
    {
        private readonly IRecommendationService _recommendationService;

        public RecommendationController(IRecommendationService recommendationService)
        {
            _recommendationService = recommendationService;
        }

        // GET: api/Recommendation/{userId}
        [HttpGet("recommendations/{userId}")]
        public async Task<IActionResult> GetRecommendations(string userId)
        {
            var recommendations = await _recommendationService.RecommendBlogsAsync(userId);

            if (recommendations == null || !recommendations.Any())
            {
                return NotFound("No recommendations available.");
            }

            return Ok(recommendations);
        }

    }
}

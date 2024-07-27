using BlogApp.Model.Domain;
using BlogApp.Model.Dto;
using BlogApp.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService)
        {
            _tagService = tagService;
        }
        [HttpPost]
        [Route("AddTag")]
        public async Task<IActionResult> AddTag([FromBody] AddTagDto tag)
        {

            if (ModelState.IsValid)
            {
                var tagResponse = await _tagService.AddAsync(tag);


                if (tagResponse.IsSuccess)
                {
                    return Ok(tagResponse);//status code 200;

                }
                return BadRequest(tagResponse);
            }

            return BadRequest("Tag controller errror");




        }
    }
}

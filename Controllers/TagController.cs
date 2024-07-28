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

        [HttpGet]
        [Route("GetTags")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await _tagService.GetAllAsync();
            if(tags == null)
            {
                return BadRequest("Tags not found");
            }
            return Ok(tags);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            var response = await _tagService.DeleteAsync(id);

            if (response.IsSuccess)
            {
                return Ok();
            }
            return BadRequest(response);
        }
    }
}

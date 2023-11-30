using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Services;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/tag")]
    public class TagController : BaseController<TagDto>
    {
        private readonly ITagService _tagService;

        public TagController(ITagService tagService) : base(tagService) 
        {
            _tagService = tagService;
        }

        [HttpGet("get:all")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var tags = await _tagService.GetAllAsync();
                return Ok(PagedList<TagDto>.ToPagedList(tags));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var tag = await _tagService.GetByIdAsync(id);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:name")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            try
            {
                var tag = await _tagService.GetByNameAsync(name);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:slug")]
        public async Task<IActionResult> GetBySlugAsync (string slug)
        {
            try
            {
                var tag = await _tagService.GetBySlugAsync(slug);
                return Ok(tag);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("set:book")]
        public async Task<IActionResult> AddOfBookAsync(string id, IEnumerable<int> tags)
        {
            try
            {
                if (tags == null)
                {
                    tags = new List<int>();
                }
                await _tagService.AddOfBookAsync(id, tags);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("get:book")]
        public async Task<IActionResult> GetOfBookAsync(string id)
        {
            try
            {
                var tags = await _tagService.GetOfBookAsync(id);
                return Ok(tags);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

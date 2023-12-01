using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Route("/post")]
    [ApiController]
    public class PostController : BaseController<PostDto>
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService) : base(postService) 
        {
            _postService = postService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var post = await _postService.GetByIdAsync(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> FilterAsync([FromQuery] PostFilter? filter, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var posts = await _postService.FilterAsync(filter, request);
                return Ok(PagedList<PostDto>.ToPagedList(posts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

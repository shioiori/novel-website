using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("get")]
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

        [HttpGet("get:all")]
        public async Task<IActionResult> FilterAsync(PostFilter filter)
        {
            try
            {
                var posts = await _postService.FilterAsync(filter);
                return Ok(PagedList<PostDto>.ToPagedList(posts));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

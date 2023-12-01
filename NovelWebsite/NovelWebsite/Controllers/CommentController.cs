using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filters;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/comment")]
    public class CommentController : BaseController<CommentDto>
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService) : base(commentService) 
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var comment = await _commentService.GetByIdAsync(id);
                return Ok(comment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("")]
        public async Task<IActionResult> FilterAsync([FromQuery] CommentFilter? filter, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var comments = await _commentService.FilterAsync(filter, request);
                return Ok(PagedList<CommentDto>.ToPagedList(comments));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("reply")]
        public async Task<IActionResult> GetRepliesAsync(string id, [FromQuery] PagedListRequest? pagedListRequest)
        {
            try
            {
                var comments = await _commentService.GetRepliesAsync(id, pagedListRequest);
                return Ok(PagedList<CommentDto>.ToPagedList(comments));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

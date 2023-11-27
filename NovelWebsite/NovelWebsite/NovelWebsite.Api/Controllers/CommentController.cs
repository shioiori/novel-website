using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/comment")]
    public class CommentController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void AddComment(CommentModel comment)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            comment.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            _commentService.CreateCommentAsync(comment);
        }
        
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        public void UpdateComment(CommentModel comment)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            comment.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            _commentService.UpdateCommentAsync(comment);
        }
        
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public void DeleteComment(string commentId)
        {
            _commentService.DeleteCommentAsync(commentId);
        }

        [HttpGet]
        [Route("get-reply-comment")]
        public async Task<PagedList<CommentModel>> GetReplyCommentAsync(string id, [FromQuery] PagedListRequest request)
        {
            var comments = await _commentService.GetReplyCommentsAsync(id, request);
            return PagedList<CommentModel>.ToPagedList(comments);
        }

        [HttpGet]
        [Route("get-comments-book")]
        public PagedList<CommentModel> GetCommentsBook(string id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfBook(id, request);
            return PagedList<CommentModel>.ToPagedList(comments);

        }

        [HttpGet]
        [Route("get-comments-post")]
        public PagedList<CommentModel> GetCommentsPost(string id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfPost(id, request);
            return PagedList<CommentModel>.ToPagedList(comments);
        }

        [HttpGet]
        [Route("get-comments-chapter")]
        public PagedList<CommentModel> GetCommentsChapter(string id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfChapter(id, request);
            return PagedList<CommentModel>.ToPagedList(comments);

        }

        [HttpGet]
        [Route("get-comments-review")]
        public PagedList<CommentModel> GetCommentsReview(string id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfReview(id, request);
            return PagedList<CommentModel>.ToPagedList(comments);
        }
    }
}

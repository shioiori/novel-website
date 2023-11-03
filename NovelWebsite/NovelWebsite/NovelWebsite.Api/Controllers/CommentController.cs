using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Route("add")]
        public void AddComment(CommentModel comment)
        {
            _commentService.CreateComment(comment);
        }

        [HttpPost]
        public void UpdateComment(CommentModel comment)
        {
            _commentService.UpdateComment(comment);
        }

        [HttpDelete]
        [Route("delete")]
        public void DeleteComment(int commentId)
        {
            _commentService.DeleteComment(commentId);
        }

        [HttpGet]
        [Route("get-reply-comment")]
        public PagedList<CommentModel> GetReplyComment(int id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetReplyComments(id);
            return PagedList<CommentModel>.ToPagedList(comments, request);
        }

        [HttpGet]
        [Route("get-comments-book")]
        public PagedList<CommentModel> GetCommentsBook(int id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfBook(id); 
            return PagedList<CommentModel>.ToPagedList(comments, request);
        }

        [HttpGet]
        [Route("get-comments-post")]
        public PagedList<CommentModel> GetCommentsPost(int id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfPost(id);
            return PagedList<CommentModel>.ToPagedList(comments, request);
        }

        [HttpGet]
        [Route("get-comments-chapter")]
        public PagedList<CommentModel> GetCommentsChapter(int id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfChapter(id);
            return PagedList<CommentModel>.ToPagedList(comments, request);
        }

        [HttpGet]
        [Route("get-comments-review")]
        public PagedList<CommentModel> GetCommentsReview(int id, [FromQuery] PagedListRequest request)
        {
            var comments = _commentService.GetCommentsOfReview(id);
            return PagedList<CommentModel>.ToPagedList(comments, request);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

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

        [HttpDelete]
        [Route("delete")]
        public void DeleteComment(int commentId)
        {
            _commentService.DeleteComment(commentId);
        }

        [HttpGet]
        [Route("get-reply-comment")]
        public IEnumerable<CommentModel> GetReplyComment(int commentId)
        {
            return _commentService.GetReplyComments(commentId);
        }
    }
}

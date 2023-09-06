using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.Application.Controllers
{
    [ApiController]
    [Route("/binh-luan")]
    [Route("/comment")]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        public void AddComment(CommentModel comment)
        {
            _commentService.CreateComment(comment);
        }

        public void DeleteComment(int commentId)
        {
           _commentService.DeleteComment(commentId);
        }

        public IEnumerable<CommentModel> GetReplyComment(int commentId)
        {
            return _commentService.GetReplyComments(commentId);
        }
    }
}

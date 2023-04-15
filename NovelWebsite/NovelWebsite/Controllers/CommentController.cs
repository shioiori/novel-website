using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Entities;
using NovelWebsite.Extensions;
using NovelWebsite.Models;

namespace NovelWebsite.Controllers
{
    public class CommentController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CommentController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(CommentModel comment)
        {
            var cmt = new CommentEntity()
            {
                ChapterId = comment.ChapterId == 0 ? null : comment.ChapterId,
                BookId = comment.BookId == 0 ? null : comment.BookId,
                UserId = comment.UserId,
                Content = StringExtension.HtmlEncode(comment.Content),
                ReplyCommentId = comment.ReplyCommentId == 0 ? null : comment.ReplyCommentId,
                PostId = comment.PostId == 0 ? null : comment.PostId,
                Likes = 0,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
            };
            _dbContext.Comments.Add(cmt);
            _dbContext.SaveChanges();
            return Json("200");
        }

        [HttpDelete]
        public IActionResult DeleteComment(int commentId)
        {
            var cmt = _dbContext.Comments.Where(c => c.ChapterId == commentId).FirstOrDefault();
            _dbContext.Comments.Remove(cmt);
            return Json("200");
        }

        public IActionResult GetReplyComment(int commentId)
        {
            var cmt = _dbContext.Comments.Where(x => x.ReplyCommentId == commentId).Include(x => x.User).ToList();
            return Json(cmt);
        }
    }
}

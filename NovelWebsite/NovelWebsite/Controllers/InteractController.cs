using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Entities;
using NovelWebsite.Models;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    [ApiController]
    [Route("/interact")]
    public class InteractController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public InteractController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [Route("/getuserid")]
        public int GetUserId()
        {
            var claims = HttpContext.User.Identity as ClaimsIdentity;
            return Int32.Parse(claims.FindFirst("UserId").Value);
        }

        [Route("get-book-fav/{bookId}")]
        public bool GetBookFav(int bookId)
        {
            int userId = GetUserId();
            var link = _dbContext.BookUserLikes.FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-book-rec/{bookId}")]
        public bool GetBookRec(int bookId)
        {
            int userId = GetUserId();
            var link = _dbContext.BookUserRecommends.FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-book-follow/{bookId}")]
        public bool GetBookFollow(int bookId)
        {
            int userId = GetUserId();
            var link = _dbContext.BookUserFollows.FirstOrDefault(x => x.BookId == bookId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-chapter-like/{chapterId}")]
        public bool GetChapterLike(int chapterId)
        {
            int userId = GetUserId();
            var link = _dbContext.ChapterUserLikes.FirstOrDefault(x => x.ChapterId == chapterId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-comment-like/{commentId}")]
        public bool GetCommentLike(int commentId)
        {
            int userId = GetUserId();
            var link = _dbContext.CommentUserLikes.FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-post-like/{postId}")]
        public bool GetPostLike(int postId)
        {
            int userId = GetUserId();
            var link = _dbContext.PostUserLikes.FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("get-review-like/{reviewId}")]
        public bool GetReviewLike(int reviewId)
        {
            int userId = GetUserId();
            var link = _dbContext.ReviewUserLikes.FirstOrDefault(x => x.ReviewId == reviewId && x.UserId == userId);
            if (link == null)
            {
                return false;
            }
            return true;
        }

        [Route("update-book-fav/{bookId}")]

        public bool UpdateBookFav(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserLikes.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserLikes.Add(new BookUserLikeEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-book-rec/{bookId}")]

        public bool UpdateBookRec(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserRecommends.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserRecommends.Add(new BookUserRecommendEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserRecommends.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-book-follow/{bookId}")]
        public bool UpdateBookFollow(int bookId)
        {
            var book = _dbContext.Books.FirstOrDefault(x => x.BookId == bookId);
            var link = _dbContext.BookUserFollows.FirstOrDefault(x => x.BookId == bookId && x.UserId == GetUserId());
            if (link == null)
            {
                _dbContext.BookUserFollows.Add(new BookUserFollowEntity()
                {
                    UserId = GetUserId(),
                    BookId = bookId,
                });
            }
            else
            {
                _dbContext.BookUserFollows.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-chapter-like/{chapterId}")]
        public bool UpdateChapterLike(int chapterId)
        {
            var chapter = _dbContext.Chapters.FirstOrDefault(x => x.ChapterId == chapterId);
            var userId = GetUserId();
            var link = _dbContext.ChapterUserLikes.FirstOrDefault(x => x.ChapterId == chapterId && x.UserId == userId);
            if (link == null)
            {
                _dbContext.ChapterUserLikes.Add(new ChapterUserLikeEntity()
                {
                    UserId = userId,
                    ChapterId = chapterId,
                });
            }
            else
            {
                _dbContext.ChapterUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-post-like/{postId}")]
        public bool UpdatePostLike(int postId)
        {
            var chapter = _dbContext.Posts.FirstOrDefault(x => x.PostId == postId);
            var userId = GetUserId();
            var link = _dbContext.PostUserLikes.FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (link == null)
            {
                _dbContext.PostUserLikes.Add(new PostUserLikeEntity()
                {
                    UserId = userId,
                    PostId = postId,
                });
            }
            else
            {
                _dbContext.PostUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-review-like/{reviewId}")]
        public bool UpdateReviewLike(int reviewId)
        {
            var review = _dbContext.Reviews.FirstOrDefault(x => x.ReviewId == reviewId);
            var userId = GetUserId();
            var link = _dbContext.ReviewUserLikes.FirstOrDefault(x => x.ReviewId == reviewId && x.UserId == userId);
            if (link == null)
            {
                _dbContext.ReviewUserLikes.Add(new ReviewUserLikeEntity()
                {
                    UserId = userId,
                    ReviewId = reviewId,
                });
            }
            else
            {
                _dbContext.ReviewUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }

        [Route("update-comment-like/{commentId}")]
        public bool UpdateCommentLike(int commentId)
        {
            var comment = _dbContext.Comments.FirstOrDefault(x => x.CommentId == commentId);
            var userId = GetUserId();
            var link = _dbContext.CommentUserLikes.FirstOrDefault(x => x.CommentId == commentId && x.UserId == userId);
            if (link == null)
            {
                _dbContext.CommentUserLikes.Add(new CommentUserLikeEntity()
                {
                    UserId = userId,
                    CommentId = commentId,
                });
            }
            else
            {
                _dbContext.CommentUserLikes.Remove(link);
            }
            _dbContext.SaveChanges();
            return true;
        }
    }
}

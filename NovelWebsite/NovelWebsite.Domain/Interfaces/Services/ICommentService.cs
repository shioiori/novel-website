using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface ICommentService
    {
        void CreateComment(CommentModel comment);
        void DeleteComment(int commentId);
        CommentModel GetComment(int commentId);
        IEnumerable<CommentModel> GetCommentsOfBook(int bookId);
        IEnumerable<CommentModel> GetCommentsOfChapter(int chapterId);
        IEnumerable<CommentModel> GetCommentsOfPost(int postId);
        IEnumerable<CommentModel> GetCommentsOfReview(int reviewId);
        IEnumerable<CommentModel> GetReplyComments(int commentId);
        void UpdateComment(CommentModel comment);
    }
}
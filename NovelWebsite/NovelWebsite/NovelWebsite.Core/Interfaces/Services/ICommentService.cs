using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface ICommentService
    {
        void CreateComment(CommentModel comment);
        void DeleteComment(string commentId);
        CommentModel GetComment(string commentId);
        IEnumerable<CommentModel> GetCommentsOfBook(string bookId);
        IEnumerable<CommentModel> GetCommentsOfChapter(string chapterId);
        IEnumerable<CommentModel> GetCommentsOfPost(string postId);
        IEnumerable<CommentModel> GetCommentsOfReview(string reviewId);
        IEnumerable<CommentModel> GetReplyComments(string commentId);
        void UpdateComment(CommentModel comment);
    }
}
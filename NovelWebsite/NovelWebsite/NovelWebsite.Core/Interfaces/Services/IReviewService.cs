using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    
    public interface IReviewService
    {
        void AddReview(ReviewModel review);
        IEnumerable<ReviewModel> GetListReviews();
        IEnumerable<ReviewModel> GetListReviewsByBookId(string bookId);
        IEnumerable<ReviewModel> GetListReviewsByCategoryId(int categoryId);
    }
}

using System.Linq.Expressions;
using NovelWebsite.Application.Models.Request;
using Application.Utils;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Application.Services
{
    public class ReviewService : GenericService<Review, ReviewDto>
    {
        private Expression<Func<Review, bool>> expSearchByBookId(string bookId)
        {
            return x => x.BookId == bookId;
        }
        private Expression<Func<Review, bool>> expSearchByCategoryId(int categoryId)
        {
            return x => categoryId == 0 || x.Book.CategoryId == categoryId;
        }

        public ReviewService() : base() { }
        public async Task<IEnumerable<ReviewDto>> GetListReviewsAsync(PagedListRequest request = null)
        {
            var query = _repository.Get();
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return await MapDtosAsync(reviews);
        }

        public async Task<IEnumerable<ReviewDto>> GetListReviewsByBookIdAsync(string bookId, PagedListRequest request = null)
        {
            var query = _repository.Get(expSearchByBookId(bookId));
            var reviews = PagedList<Review>.AsEnumerable(query, request); 
            return await MapDtosAsync(reviews);

        }

        public async Task<IEnumerable<ReviewDto>> GetListReviewsByCategoryIdAsync(int categoryId, PagedListRequest request = null)
        {
            if (categoryId == 0)
            {
                return await GetListReviewsAsync(request);
            }
            var query = _repository.Get(expSearchByCategoryId(categoryId));
            var reviews = PagedList<Review>.AsEnumerable(query, request); 
            return await MapDtosAsync(reviews);

        }
    }
}

using System.Linq.Expressions;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Utils;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class ReviewService : GenericService<Review, ReviewDto>, IReviewService
    {
        public ReviewService(IReviewRepository reviewRepository, IMapper mapper) : base(reviewRepository, mapper) { }
        public async Task<IEnumerable<ReviewDto>> FilterAsync(ReviewFilter filter, PagedListRequest request)
        {
            var query = _repository.Get();
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }
            if (filter.BookId != null)
            {
                query = query.Where(x => x.BookId == filter.BookId);
            }
            if (filter.CategoryId != null)
            {
                query = query.Where(x => x.Book.CategoryId == filter.CategoryId);
            }
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return await MapDtosAsync(reviews);
        }

        public async Task<ReviewDto> GetByIdAsync(string reviewId)
        {
            var review = _repository.Get(x => x.ReviewId == reviewId).FirstOrDefault();
            return await MapDtoAsync(review);

        }
    }
}

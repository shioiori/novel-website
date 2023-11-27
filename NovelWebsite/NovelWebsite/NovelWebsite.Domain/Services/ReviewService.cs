using System.Linq.Expressions;
using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ReviewService 
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        private Expression<Func<Review, bool>> expSearchByBookId(string bookId)
        {
            return x => x.BookId == bookId;
        }
        private Expression<Func<Review, bool>> expSearchByCategoryId(int categoryId)
        {
            return x => categoryId == 0 || x.Book.CategoryId == categoryId;
        }

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public IEnumerable<ReviewModel> GetListReviews(PagedListRequest request = null)
        {
            var query = _reviewRepository.GetAll();
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public IEnumerable<ReviewModel> GetListReviewsByBookId(string bookId, PagedListRequest request = null)
        {
            var query = _reviewRepository.Filter(expSearchByBookId(bookId));
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public IEnumerable<ReviewModel> GetListReviewsByCategoryId(int categoryId, PagedListRequest request = null)
        {
            if (categoryId == 0)
            {
                return GetListReviews(request);
            }
            var query = _reviewRepository.Filter(expSearchByCategoryId(categoryId));
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public async Task AddAsync(ReviewModel review)
        {
            await _reviewRepository.InsertAsync(_mapper.Map<ReviewModel, Review>(review));
            _reviewRepository.SaveAsync();
        }

        public async Task UpdateAsync(ReviewModel review)
        {
            await _reviewRepository.UpdateAsync(_mapper.Map<ReviewModel, Review>(review));
            _reviewRepository.SaveAsync();
        }

        public async Task DeleteAsync(string reviewId)
        {
            await _reviewRepository.DeleteAsync(reviewId);
            _reviewRepository.SaveAsync();
        }
    }
}

using System.Linq.Expressions;
using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Enums;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.Application.Models.Request;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Application.Utils;
using Application.Models.Dtos;

namespace NovelWebsite.Application.Services
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

        public IEnumerable<ReviewDto> GetListReviews(PagedListRequest request = null)
        {
            var query = _reviewRepository.GetAll();
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDto>>(reviews);
        }

        public IEnumerable<ReviewDto> GetListReviewsByBookId(string bookId, PagedListRequest request = null)
        {
            var query = _reviewRepository.Get(expSearchByBookId(bookId));
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDto>>(reviews);
        }

        public IEnumerable<ReviewDto> GetListReviewsByCategoryId(int categoryId, PagedListRequest request = null)
        {
            if (categoryId == 0)
            {
                return GetListReviews(request);
            }
            var query = _reviewRepository.Get(expSearchByCategoryId(categoryId));
            var reviews = PagedList<Review>.AsEnumerable(query, request);
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewDto>>(reviews);
        }

        public async Task AddAsync(ReviewDto review)
        {
            await _reviewRepository.InsertAsync(_mapper.Map<ReviewDto, Review>(review));
            _reviewRepository.SaveAsync();
        }

        public async Task UpdateAsync(ReviewDto review)
        {
            await _reviewRepository.UpdateAsync(_mapper.Map<ReviewDto, Review>(review));
            _reviewRepository.SaveAsync();
        }

        public async Task DeleteAsync(string reviewId)
        {
            await _reviewRepository.DeleteAsync(reviewId);
            _reviewRepository.SaveAsync();
        }
    }
}

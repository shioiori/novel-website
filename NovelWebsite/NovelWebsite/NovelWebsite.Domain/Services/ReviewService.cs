using System.Linq.Expressions;
using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class ReviewService : IReviewService
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

        public IEnumerable<ReviewModel> GetListReviews()
        {
            var reviews = _reviewRepository.GetAll();
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public IEnumerable<ReviewModel> GetListReviewsByBookId(string bookId)
        {
            var reviews = _reviewRepository.Filter(expSearchByBookId(bookId));
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public IEnumerable<ReviewModel> GetListReviewsByCategoryId(int categoryId)
        {
            if (categoryId == 0)
            {
                return GetListReviews();
            }
            var reviews = _reviewRepository.Filter(expSearchByCategoryId(categoryId));
            return _mapper.Map<IEnumerable<Review>, IEnumerable<ReviewModel>>(reviews);
        }

        public void AddReview(ReviewModel review)
        {
            _reviewRepository.Insert(_mapper.Map<ReviewModel, Review>(review));
            _reviewRepository.Save();
        }
    }
}

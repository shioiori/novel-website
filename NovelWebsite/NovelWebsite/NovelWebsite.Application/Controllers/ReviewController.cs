using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{
    public class ReviewController : Controller
    {
        Expression<Func<ReviewModel, object>> expOrderByCreatedDate = x => x.CreatedDate;
        private readonly IReviewService _reviewService;
        private readonly ICategoryService _categoryService;

        public ReviewController(IReviewService reviewService, ICategoryService categoryService)
        {
            _reviewService = reviewService;
            _categoryService = categoryService;
        }
        public IActionResult Index(string? category, int sort_by = (int)SortOrder.Descending)
        {
            var cate = _categoryService.GetCategory(category);
            var id = cate == null ? 0 : cate.CategoryId;
            var reviews = _reviewService.GetListReviewsByCategoryId(id);
            switch ((SortOrder)sort_by){
                case SortOrder.Ascending:
                    reviews = reviews.OrderBy(expOrderByCreatedDate.Compile());
                    break;
                case SortOrder.Descending:
                    reviews = reviews.OrderByDescending(expOrderByCreatedDate.Compile());
                    break;
                default:
                    break;
            }
            // ViewBag.categoryId = categoryId;
            // ViewBag.sortBy = sort_by;
            // ViewBag.category = _dbContext.Categories.ToList();
            // PagedList<ReviewEntity> listReview = new PagedList<ReviewEntity>(reviews, pageNumber, pageSize);
            return View(reviews);
        }

        [HttpPost]
        public IActionResult AddReview(ReviewModel review)
        {
            _reviewService.AddReview(review);
            return NoContent();
        }
    }
}

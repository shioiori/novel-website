using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.Application.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _service;
        Expression<Func<ReviewModel, object>> expOrderByCreatedDate = x => x.CreatedDate; 

        public ReviewController(IReviewService service)
        {
            _service = service;
        }
        public IActionResult Index(int sort_by, int categoryId = 0, int pageNumber = 1, int pageSize = 8)
        {
            var reviews = _service.GetListReviewsByCategoryId(categoryId);
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
            _service.AddReview(review);
            return NoContent();
        }
    }
}

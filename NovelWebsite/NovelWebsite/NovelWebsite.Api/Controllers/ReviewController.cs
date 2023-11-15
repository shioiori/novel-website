using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/review")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly ReviewService _reviewService;
        private readonly CategoryService _categoryService;

        public ReviewController(ReviewService reviewService, CategoryService categoryService)
        {
            _reviewService = reviewService;
            _categoryService = categoryService;
        }

        [HttpGet]
        [Route("get-by-filter")]
        public PagedList<ReviewModel> GetByFilter(string? category, string? orderDate, [FromQuery] PagedListRequest request)
        {
            int categoryId = 0;
            if (!string.IsNullOrEmpty(category))
            {
                if (!int.TryParse(category, out categoryId))
                {
                    categoryId = (int)_categoryService.GetCategory(category)?.CategoryId;
                }
            }
            IEnumerable<ReviewModel> reviews;
            if (categoryId != 0)
            {
                reviews = _reviewService.GetListReviewsByCategoryId(categoryId);
            }
            else
            {
                reviews = _reviewService.GetListReviews();
            }
            SortOrder ordDate = SortOrder.Descending;
            if (!string.IsNullOrEmpty(orderDate))
            {
                if (int.TryParse(orderDate, out int ord))
                {
                    ordDate = (SortOrder)ord;
                }
                else
                {
                    ordDate = (SortOrder)Enum.Parse(typeof(SortOrder), orderDate, true);
                }
            }
            switch ((SortOrder)ordDate)
            {
                case SortOrder.Ascending:
                    reviews = reviews.OrderBy(x => x.CreatedDate);
                    break;
                case SortOrder.Descending:
                    reviews = reviews.OrderByDescending(x => x.CreatedDate);
                    break;
                default:
                    break;
            }
            return PagedList<ReviewModel>.ToPagedList(reviews);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public IActionResult AddReview(ReviewModel review)
        {
            _reviewService.AddReview(review);
            return NoContent();
        }
    }
}

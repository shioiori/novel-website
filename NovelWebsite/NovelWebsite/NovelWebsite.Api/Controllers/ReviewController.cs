using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;

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
		[Route("get-by-book")]
		public PagedList<ReviewModel> GetByBook(string bookId, [FromQuery] PagedListRequest request)
		{
			var reviews = _reviewService.GetListReviewsByBookId(bookId, request);
		    return PagedList<ReviewModel>.ToPagedList(reviews);
        }
		[HttpGet]
        [Route("get-by-filter")]
        public PagedList<ReviewModel> GetByFilter(string orderDate, int category = 0, [FromQuery] PagedListRequest request = null)
        {
            IEnumerable<ReviewModel> reviews;
            if (category != 0)
            {
                reviews = _reviewService.GetListReviewsByCategoryId(category, request);
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

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("add")]
        public IActionResult Add(ReviewModel review)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                review.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _reviewService.AddAsync(review);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("update")]
        public IActionResult Update(ReviewModel review)
        {
            try
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                review.UserId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
                _reviewService.UpdateAsync(review);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("delete")]
        public IActionResult Delete(string reviewId)
        {
            try
            {
                _reviewService.DeleteAsync(reviewId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

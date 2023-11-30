using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filter;
using Application.Utils;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Route("/review")]
    [ApiController]
    public class ReviewController : BaseController<ReviewDto>
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService) : base(reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var post = await _reviewService.GetByIdAsync(id);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:all")]
        public async Task<IActionResult> FilterAsync(ReviewFilter filter)
        {
            try
            {
                var reviews = await _reviewService.FilterAsync(filter);
                return Ok(PagedList<ReviewDto>.ToPagedList(reviews));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

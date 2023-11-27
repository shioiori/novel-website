using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;
using NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/review")]
    public class ReviewInteractionController : ControllerBase
    {
        private readonly ReviewInteractionService _reviewInteractionService;
        private readonly UserService _userService;

        public ReviewInteractionController(ReviewInteractionService reviewInteractionService, UserService userService)
        {
            _reviewInteractionService = reviewInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public async Task<bool> IsReviewLikedAsync(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _reviewInteractionService.IsInteractionEnabledAsync(reviewId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public async Task<bool> IsReviewDislikedAsync(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _reviewInteractionService.IsInteractionEnabledAsync(reviewId, userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public async Task<bool> SetReviewLikeAsync(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _reviewInteractionService.SetStatusOfInteractionAsync(reviewId, userId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public async Task<bool> SetReviewDislikeAsync(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _reviewInteractionService.SetStatusOfInteractionAsync(reviewId, userId, InteractionType.Dislike);
        }

    }
}

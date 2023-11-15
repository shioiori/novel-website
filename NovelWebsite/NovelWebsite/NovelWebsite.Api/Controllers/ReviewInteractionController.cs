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
        public bool IsReviewLiked(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _reviewInteractionService.IsInteractionEnabled(reviewId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsReviewDisliked(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _reviewInteractionService.IsInteractionEnabled(reviewId, userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetReviewLike(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, userId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public bool SetReviewDislike(string reviewId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, userId, InteractionType.Dislike);
        }

    }
}

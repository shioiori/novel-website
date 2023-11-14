using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{

    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/review")]
    public class ReviewInteractionController : ControllerBase
    {
        private readonly ReviewInteractionService _reviewInteractionService;
        private readonly IUserService _userService;

        public ReviewInteractionController(ReviewInteractionService reviewInteractionService, IUserService userService)
        {
            _reviewInteractionService = reviewInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsReviewLiked(string reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.IsInteractionEnabled(reviewId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsReviewDisliked(string reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.IsInteractionEnabled(reviewId, user.UserId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetReviewLike(string reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public bool SetReviewDislike(string reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, user.UserId, InteractionType.Dislike);
        }

    }
}

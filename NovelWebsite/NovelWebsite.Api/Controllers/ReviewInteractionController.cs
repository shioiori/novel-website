using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{
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
        public bool IsReviewLiked(int reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.IsInteractionEnabled(reviewId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsReviewDisliked(int reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.IsInteractionEnabled(reviewId, user.UserId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetReviewLike(int reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public bool SetReviewDislike(int reviewId)
        {
            var user = _userService.GetCurrentUser();
            return _reviewInteractionService.SetStatusOfInteraction(reviewId, user.UserId, InteractionType.Dislike);
        }

    }
}

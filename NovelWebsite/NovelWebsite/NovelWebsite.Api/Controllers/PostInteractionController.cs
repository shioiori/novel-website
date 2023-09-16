using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/interact/post")]
    public class PostInteractionController : ControllerBase
    {
        private readonly PostInteractionService _postInteractionService;
        private readonly IUserService _userService;

        public PostInteractionController(PostInteractionService postInteractionService, IUserService userService)
        {
            _postInteractionService = postInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsPostLiked(int postId)
        {
            var user = _userService.GetCurrentUser();
            return _postInteractionService.IsInteractionEnabled(postId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsPostDisliked(int postId)
        {
            var user = _userService.GetCurrentUser();
            return _postInteractionService.IsInteractionEnabled(postId, user.UserId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetPostLike(int postId)
        {
            var user = _userService.GetCurrentUser();
            return _postInteractionService.SetStatusOfInteraction(postId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-disliked")]
        [HttpGet]
        public bool SetPostDislike(int postId)
        {
            var user = _userService.GetCurrentUser();
            return _postInteractionService.SetStatusOfInteraction(postId, user.UserId, InteractionType.Dislike);
        }

    }
}

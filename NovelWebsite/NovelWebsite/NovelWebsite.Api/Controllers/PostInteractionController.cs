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
    [Route("/interact/post")]
    public class PostInteractionController : ControllerBase
    {
        private readonly PostInteractionService _postInteractionService;
        private readonly UserService _userService;

        public PostInteractionController(PostInteractionService postInteractionService, UserService userService)
        {
            _postInteractionService = postInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsPostLiked(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _postInteractionService.IsInteractionEnabled(postId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsPostDisliked(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _postInteractionService.IsInteractionEnabled(postId, userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetPostLike(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _postInteractionService.SetStatusOfInteraction(postId, userId, InteractionType.Like);
        }

        [Route("set-status-disliked")]
        [HttpGet]
        public bool SetPostDislike(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _postInteractionService.SetStatusOfInteraction(postId, userId, InteractionType.Dislike);
        }

    }
}

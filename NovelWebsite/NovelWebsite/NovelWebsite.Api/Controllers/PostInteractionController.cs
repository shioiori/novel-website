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
        public async Task<bool> IsPostLikedAsync(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _postInteractionService.IsInteractionEnabledAsync(postId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public async Task<bool> IsPostDislikedAsync(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _postInteractionService.IsInteractionEnabledAsync(postId, userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public async Task<bool> SetPostLikeAsync(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _postInteractionService.SetStatusOfInteractionAsync(postId, userId, InteractionType.Like);
        }

        [Route("set-status-disliked")]
        [HttpGet]
        public async Task<bool> SetPostDislikeAsync(string postId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _postInteractionService.SetStatusOfInteractionAsync(postId, userId, InteractionType.Dislike);
        }

    }
}

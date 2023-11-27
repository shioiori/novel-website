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
    [Route("/interact/comment")]
    public class CommentInteractionController : ControllerBase
    {
        private readonly CommentInteractionService _commentInteractionService;
        private readonly UserService _userService;

        public CommentInteractionController(CommentInteractionService commentInteractionService, UserService userService)
        {
            _commentInteractionService = commentInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public async Task<bool> IsCommentLikedAsync(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _commentInteractionService.IsInteractionEnabledAsync(commentId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public async Task<bool> IsCommentDislikedAsync(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _commentInteractionService.IsInteractionEnabledAsync(commentId, userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public async Task<bool> SetCommentLikeAsync(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _commentInteractionService.SetStatusOfInteractionAsync(commentId, userId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public async Task<bool> SetCommentDislikeAsync(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _commentInteractionService.SetStatusOfInteractionAsync(commentId, userId, InteractionType.Dislike);
        }

    }
}

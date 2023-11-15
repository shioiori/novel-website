using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/comment")]
    public class CommentInteractionController : ControllerBase
    {
        private readonly CommentInteractionService _commentInteractionService;
        private readonly IUserService _userService;

        public CommentInteractionController(CommentInteractionService commentInteractionService, IUserService userService)
        {
            _commentInteractionService = commentInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsCommentLiked(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _commentInteractionService.IsInteractionEnabled(commentId,userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsCommentDisliked(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _commentInteractionService.IsInteractionEnabled(commentId,userId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetCommentLike(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _commentInteractionService.SetStatusOfInteraction(commentId,userId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public bool SetCommentDislike(string commentId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _commentInteractionService.SetStatusOfInteraction(commentId,userId, InteractionType.Dislike);
        }

    }
}

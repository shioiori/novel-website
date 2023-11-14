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
            var user = _userService.GetCurrentUser();
            return _commentInteractionService.IsInteractionEnabled(commentId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsCommentDisliked(string commentId)
        {
            var user = _userService.GetCurrentUser();
            return _commentInteractionService.IsInteractionEnabled(commentId, user.UserId, InteractionType.Dislike);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetCommentLike(string commentId)
        {
            var user = _userService.GetCurrentUser();
            return _commentInteractionService.SetStatusOfInteraction(commentId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-dislike")]
        [HttpGet]
        public bool SetCommentDislike(string commentId)
        {
            var user = _userService.GetCurrentUser();
            return _commentInteractionService.SetStatusOfInteraction(commentId, user.UserId, InteractionType.Dislike);
        }

    }
}

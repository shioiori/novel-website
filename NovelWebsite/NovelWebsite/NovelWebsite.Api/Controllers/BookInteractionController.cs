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
    [Route("/interact/book")]
    public class BookInteractionController : ControllerBase
    {
        private readonly BookInteractionService _bookInteractionService;
        private readonly IUserService _userService;

        public BookInteractionController(BookInteractionService bookInteractionService, IUserService userService)
        {
            _bookInteractionService = bookInteractionService;
            _userService = userService;
        }


        [Route("is-liked")]
        [HttpGet]
        public bool IsBookLiked(string bookId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.IsInteractionEnabled(bookId, userId, InteractionType.Like);
        }

        [Route("is-recommended")]
        [HttpGet]
        public bool IsBookRecommended(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.IsInteractionEnabled(bookId, userId, InteractionType.Recommend);
        }

        [Route("is-followed")]
        [HttpGet]
        public bool IsBookFollowed(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.IsInteractionEnabled(bookId, userId, InteractionType.Follow);
        }

        [HttpGet]
        [Route("set-status-like")]

        public bool SetBookLike(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.SetStatusOfInteraction(bookId, userId, InteractionType.Like);
        }

        [HttpGet]
        [Route("set-status-recommend")]

        public bool SetBookRecommend(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.SetStatusOfInteraction(bookId, userId, InteractionType.Recommend);
        }

        [HttpGet]
        [Route("set-status-follow")]
        public bool SetBookFollow(string bookId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _bookInteractionService.SetStatusOfInteraction(bookId, userId, InteractionType.Follow);
        }
    }
}

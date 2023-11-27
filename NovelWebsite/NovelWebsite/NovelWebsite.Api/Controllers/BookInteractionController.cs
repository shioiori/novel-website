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
    [Route("/interact/book")]
    public class BookInteractionController : ControllerBase
    {
        private readonly BookInteractionService _bookInteractionService;
        private readonly UserService _userService;

        public BookInteractionController(BookInteractionService bookInteractionService, UserService userService)
        {
            _bookInteractionService = bookInteractionService;
            _userService = userService;
        }


        [Route("is-liked")]
        [HttpGet]
        public async Task<bool> IsBookLikedAsync(string bookId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.IsInteractionEnabledAsync(bookId, userId, InteractionType.Like);
        }

        [Route("is-recommended")]
        [HttpGet]
        public async Task<bool> IsBookRecommendedAsync(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.IsInteractionEnabledAsync(bookId, userId, InteractionType.Recommend);
        }

        [Route("is-followed")]
        [HttpGet]
        public async Task<bool> IsBookFollowedAsync(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.IsInteractionEnabledAsync(bookId, userId, InteractionType.Follow);
        }

        [HttpGet]
        [Route("set-status-like")]

        public async Task<bool> SetBookLikeAsync(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.SetStatusOfInteractionAsync(bookId, userId, InteractionType.Like);
        }

        [HttpGet]
        [Route("set-status-recommend")]

        public async Task<bool> SetBookRecommendAsync(string bookId)
        {

            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.SetStatusOfInteractionAsync(bookId, userId, InteractionType.Recommend);
        }

        [HttpGet]
        [Route("set-status-follow")]
        public async Task<bool> SetBookFollowAsync(string bookId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _bookInteractionService.SetStatusOfInteractionAsync(bookId, userId, InteractionType.Follow);
        }
    }
}

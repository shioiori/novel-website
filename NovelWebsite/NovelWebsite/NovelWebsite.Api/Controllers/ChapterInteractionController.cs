using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Security.Claims;
using NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/chapter")]
    public class ChapterInteractionController : ControllerBase
    {
        private readonly ChapterInteractionService _chapterInteractionService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserService _userService;

        public ChapterInteractionController(ChapterInteractionService chapterInteractionService, UserService userService,
            UserManager<User> userManager)
        {
            _chapterInteractionService = chapterInteractionService;
            _userManager = userManager;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public async Task<bool> IsChapterLikedAsync(string chapterId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _chapterInteractionService.IsInteractionEnabledAsync(chapterId, userId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public async Task<bool> IsChapterMarkedAsync(string chapterId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _chapterInteractionService.IsInteractionEnabledAsync(chapterId, userId, InteractionType.Mark);
        }

        [Route("set-status-like")]
        [HttpGet]
        public async Task<bool> SetChapterLikeAsync(string chapterId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _chapterInteractionService.SetStatusOfInteractionAsync(chapterId, userId, InteractionType.Like);
        }

        [Route("set-status-mark")]
        [HttpGet]

        public async Task<bool> SetChapterMarkAsync(string chapterId)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var userId = identity.FindFirst(ClaimTypes.NameIdentifier).Value;
            return await _chapterInteractionService.SetStatusOfInteractionAsync(chapterId, userId, InteractionType.Mark);
        }
    }
}

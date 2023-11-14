using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

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
        private readonly IUserService _userService;

        public ChapterInteractionController(ChapterInteractionService chapterInteractionService, IUserService userService,
            UserManager<User> userManager)
        {
            _chapterInteractionService = chapterInteractionService;
            _userManager = userManager;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsChapterLiked(string chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.IsInteractionEnabled(chapterId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsChapterMarked(string chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.IsInteractionEnabled(chapterId, user.UserId, InteractionType.Mark);
        }

        [Route("set-status-like")]
        [HttpGet]
        public bool SetChapterLike(string chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.SetStatusOfInteraction(chapterId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-mark")]
        [HttpGet]

        public bool SetChapterMark(string chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.SetStatusOfInteraction(chapterId, user.UserId, InteractionType.Mark);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{
    [ApiController]
    [Route("/interact/xhapter")]
    public class ChapterInteractionController : ControllerBase
    {
        private readonly ChapterInteractionService _chapterInteractionService;
        private readonly IUserService _userService;

        public ChapterInteractionController(ChapterInteractionService chapterInteractionService, IUserService userService)
        {
            _chapterInteractionService = chapterInteractionService;
            _userService = userService;
        }

        [Route("is-liked")]
        [HttpGet]
        public bool IsChapterLiked(int chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.IsInteractionEnabled(chapterId, user.UserId, InteractionType.Like);
        }

        [Route("is-disliked")]
        [HttpGet]
        public bool IsChapterMarked(int chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.IsInteractionEnabled(chapterId, user.UserId, InteractionType.Mark);
        }

        [Route("set-status-like")]
        public bool SetChapterLike(int chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.SetStatusOfInteraction(chapterId, user.UserId, InteractionType.Like);
        }

        [Route("set-status-mark")]
        public bool SetChapterMark(int chapterId)
        {
            var user = _userService.GetCurrentUser();
            return _chapterInteractionService.SetStatusOfInteraction(chapterId, user.UserId, InteractionType.Mark);
        }
    }
}

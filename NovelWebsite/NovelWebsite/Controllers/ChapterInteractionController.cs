using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("/interact/chapter")]
    public class ChapterInteractionController : InteractionController
    {
        private readonly IChapterInteractionService _chapterInteractionService;

        public ChapterInteractionController(IChapterInteractionService chapterInteractionService) : base(chapterInteractionService)
        {
            _chapterInteractionService = chapterInteractionService;
        }

    }
}

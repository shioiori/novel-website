using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Application.Controllers
{

    [Route("/truyen")]
    public class ChapterController : Controller
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [Route("{slug}-{id:int}/chuong-{chapterNumber:int}/{chapterSlug}-{chapterId:int}")]
        public IActionResult Index(int chapterId)
        {
            var chapter = _chapterService.GetChapter(chapterId);
            ViewBag.PrevChapter = _chapterService.GetPrevChapter(chapterId); 
            ViewBag.NextChapter = _chapterService.GetNextChapter(chapterId);
            return View(chapter);
        }

        [Route("{action}")]
        public IActionResult GetListChapters(int bookId)
        {
            var listChapters = _chapterService.GetChapters(bookId);
            return Json(listChapters);
        }

        [Route("{action}")]
        public IActionResult DeleteChapter(int chapterId)
        {
            _chapterService.DeleteChapter(chapterId);
            return Json("");
        }
    }
}

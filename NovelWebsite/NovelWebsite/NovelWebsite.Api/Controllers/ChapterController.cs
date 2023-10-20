using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.Api.Controllers
{

    [Route("/chapter")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService)
        {
            _chapterService = chapterService;
        }

        [HttpGet]
        [Route("get-by-chapter-id")]
        public ChapterModel GetByChapter(int chapterId)
        {
            return _chapterService.GetChapter(chapterId);
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public IEnumerable<ChapterModel> GetListChapters(int bookId)
        {
            return _chapterService.GetChapters(bookId);
        }

        [HttpPost]
        [Route("add")]
        public void AddChapter(ChapterModel model){
            _chapterService.CreateChapter(model);
        }

        [HttpPost]
        [Route("update")]
        public void UpdateChapter(ChapterModel model){
            _chapterService.UpdateChapter(model);
        }

        [Route("delete")]
        [HttpDelete]
        public void DeleteChapter(int chapterId)
        {
            _chapterService.DeleteChapter(chapterId);
        }
    }
}

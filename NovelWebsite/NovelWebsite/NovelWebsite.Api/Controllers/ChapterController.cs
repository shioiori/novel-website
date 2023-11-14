using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
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
        public ChapterModel GetByChapter(string chapterId)
        {
            return _chapterService.GetChapter(chapterId);
        }

        [HttpGet]
        [Route("get-by-book-id")]
        public PagedList<ChapterModel> GetListChapters(string bookId, PagedListRequest request)
        {
            var chapters = _chapterService.GetChapters(bookId);
            return PagedList<ChapterModel>.ToPagedList(chapters, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void AddChapter(ChapterModel model){
            _chapterService.CreateChapter(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void UpdateChapter(ChapterModel model){
            _chapterService.UpdateChapter(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("delete")]
        [HttpDelete]
        public void DeleteChapter(string chapterId)
        {
            _chapterService.DeleteChapter(chapterId);
        }
    }
}

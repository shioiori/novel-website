using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Enums;
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
        private readonly ChapterService _chapterService;

        public ChapterController(ChapterService chapterService)
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
        [Route("get-by-chapter-index")]
        public ChapterModel GetByChapter(string bookId, int index)
        {
            return _chapterService.GetChapter(bookId, index);
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<ChapterModel> GetListChapters(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChapters(bookId);
            return PagedList<ChapterModel>.ToPagedList(chapters, request);
        }

        [HttpGet]
        [Route("get-all-published")]
        public PagedList<ChapterModel> GetListChaptersPublished(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChaptersByStatus(bookId, UploadStatus.Publish);
            return PagedList<ChapterModel>.ToPagedList(chapters, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("get-all-draft")]
        public PagedList<ChapterModel> GetListChaptersDraft(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChaptersByStatus(bookId, UploadStatus.Draft);
            return PagedList<ChapterModel>.ToPagedList(chapters, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public IActionResult AddChapter(ChapterModel model){
            try
            {
                _chapterService.CreateChapter(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public IActionResult UpdateChapter(ChapterModel model){
            try
            {
                _chapterService.UpdateChapter(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [Route("delete")]
        [HttpDelete]
        public IActionResult DeleteChapter(string chapterId)
        {
            try
            {
                _chapterService.DeleteChapter(chapterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

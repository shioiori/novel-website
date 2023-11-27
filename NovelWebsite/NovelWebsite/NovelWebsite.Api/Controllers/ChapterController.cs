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
using NovelWebsite.NovelWebsite.Infrastructure.Entities;

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
        public async Task<ChapterModel> GetByChapterAsync(string chapterId)
        {
            return await _chapterService.GetChapterAsync(chapterId);
        }

        [HttpGet]
        [Route("get-by-chapter-index")]
        public async Task<ChapterModel> GetByChapterAsync(string bookId, int index)
        {
            return await _chapterService.GetChapterAsync(bookId, index);
        }

        [HttpGet]
        [Route("get-all")]
        public PagedList<ChapterModel> GetListChapters(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChapters(bookId, request);
            return PagedList<ChapterModel>.ToPagedList(chapters);
        }

        [HttpGet]
        [Route("get-all-published")]
        public PagedList<ChapterModel> GetListChaptersPublished(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChaptersByStatus(bookId, UploadStatus.Publish, request);
            return PagedList<ChapterModel>.ToPagedList(chapters);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("get-all-draft")]
        public PagedList<ChapterModel> GetListChaptersDraft(string bookId, [FromQuery] PagedListRequest request)
        {
            var chapters = _chapterService.GetChaptersByStatus(bookId, UploadStatus.Draft, request);
            return PagedList<ChapterModel>.ToPagedList(chapters);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public IActionResult AddChapter(ChapterModel model){
            try
            {
                _chapterService.CreateChapterAsync(model);
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
                _chapterService.UpdateChapterAsync(model);
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
                _chapterService.DeleteChapterAsync(chapterId);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}

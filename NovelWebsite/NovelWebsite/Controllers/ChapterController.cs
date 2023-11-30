using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filters;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;

namespace NovelWebsite.Controllers
{
    [Route("/chapter")]
    [ApiController]
    public class ChapterController : BaseController<ChapterDto>
    {
        private readonly IChapterService _chapterService;

        public ChapterController(IChapterService chapterService) : base(chapterService)
        {
            _chapterService = chapterService;
        }


        [HttpGet("get:id")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                return Ok(await _chapterService.GetAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:index")]
        public async Task<IActionResult> GetByIndexAsync(string id, int index)
        {
            try
            {
                return Ok(await _chapterService.GetAsync(id, index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:prev/{id}")]
        public async Task<IActionResult> GetPrevAsync(string id)
        {
            try
            {
                return Ok(await _chapterService.GetPrevAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:prev/{id}-{index}")]
        public async Task<IActionResult> GetPrevAsync(string id, int index)
        {
            try
            {
                return Ok(await _chapterService.GetPrevAsync(id, index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:next/{id}")]
        public async Task<IActionResult> GetNextAsync(string id)
        {
            try
            {
                return Ok(await _chapterService.GetNextAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:next/{id}-{index}")]
        public async Task<IActionResult> GetNextAsync(string id, int index)
        {
            try
            {
                return Ok(await _chapterService.GetPrevAsync(id, index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("get:all")]
        public async Task<IActionResult> GetListChapters([FromQuery] ChapterFilter filter)
        {
            try
            {
                var chapters = await _chapterService.FilterAsync(filter);
                return Ok(PagedList<ChapterDto>.ToPagedList(chapters));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

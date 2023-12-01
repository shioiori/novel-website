using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filters;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
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


        [HttpGet("{id}")]
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

        [HttpGet("{id}-{index}")]
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

        [HttpGet("prev/{id}")]
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

        [HttpGet("prev/{id}-{index}")]
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

        [HttpGet("next/{id}")]
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

        [HttpGet("next/{id}-{index}")]
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

        [HttpGet("")]
        public async Task<IActionResult> GetListChapters([FromQuery] ChapterFilter? filter, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var chapters = await _chapterService.FilterAsync(filter, request);
                return Ok(PagedList<ChapterDto>.ToPagedList(chapters));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

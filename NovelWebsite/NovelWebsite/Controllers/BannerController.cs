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
    [ApiController]
    [Route("/banner")]
    public class BannerController : BaseController<BannerDto>
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService bannerService) : base(bannerService) { 
            _bannerService = bannerService;
        }

        [HttpGet("")]
        public async Task<IActionResult> FilterAsync([FromQuery] BannerFilter? filter, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var banners = await _bannerService.FilterAsync(filter, request);
                return Ok(PagedList<BannerDto>.ToPagedList(banners));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var banner = await _bannerService.GetByIdAsync(id);
                return Ok(banner);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

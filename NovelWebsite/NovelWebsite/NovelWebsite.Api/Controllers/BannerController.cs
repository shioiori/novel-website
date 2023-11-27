using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using NovelWebsite.NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Domain.Utils;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [ApiController]
    [Route("/banner")]
    public class BannerController : ControllerBase
    {
        private readonly BannerService _bannerService;

        public BannerController(BannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        [Route("get-home-banner")]
        public PagedList<BannerModel> GetHomeBanner([FromQuery] PagedListRequest request)
        {
            var banners = _bannerService.GetBannersByTypeAsync(BannerType.Home);
            return PagedList<BannerModel>.ToPagedList(banners);
        }

        [HttpGet]
        [Route("get-random-advertise-banner")]
        public BannerModel GetRandomAdvertiseBanner([FromQuery] PagedListRequest request)
        {
            var banners = _bannerService.GetBannersByTypeAsync(BannerType.Advertise);
            if (banners == null || banners.Count() == 0)
            {
                return null;
            }
            return RandomUtil<BannerModel>.GetRandom(banners, banners.Count());
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void AddBanner(BannerModel banner)
        {
            _bannerService.CreateBannerAsync(banner);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void UpdateBanner(BannerModel banner)
        {
            _bannerService.UpdateBannerAsync(banner);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public void DeleteBanner(int id)
        {
            _bannerService.DeleteBannerAsync(id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Utils;

namespace NovelWebsite.Application.Controllers
{
    [ApiController]
    [Route("/banner")]
    public class BannerController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        [Route("get-home-banner")]
        public IEnumerable<BannerModel> GetHomeBanner(int number = 3)
        {
            return _bannerService.GetBannersByType(BannerType.Home).Take(number);
        }

        [HttpGet]
        [Route("get-random-advertise-banner")]
        public BannerModel GetRandomAdvertiseBanner()
        {
            var banners = _bannerService.GetBannersByType(BannerType.Advertise);
            return RandomUtil<BannerModel>.GetRandom(banners, banners.Count());
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Domain.Services;

namespace NovelWebsite.NovelWebsite.Application.Components.HomeViewComponent
{
    public class HomeBannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;

        public HomeBannerViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke(DateTime dateTime, int number = 3)
        {
            var banners = _bannerService.GetActiveBannersByType(BannerType.Home, dateTime).Take(number);
            return View(banners);
        }
    }
}

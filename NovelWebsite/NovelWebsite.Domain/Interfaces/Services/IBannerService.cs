using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBannerService
    {
        void CreateBanner(BannerModel banner);
        void DeleteBanner(object bannerId);
        IEnumerable<BannerModel> GetActiveBanners(DateTime dateTime);
        IEnumerable<BannerModel> GetActiveBannersByType(BannerType type, DateTime dateTime);
        IEnumerable<BannerModel> GetAllBanner();
        BannerModel GetBanner(object id);
        IEnumerable<BannerModel> GetBannersByType(BannerType type);
        void UpdateBanner(BannerModel banner);
    }
}

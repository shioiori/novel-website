using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBannerService
    {
        IEnumerable<BannerModel> GetBannersByType(BannerType type);
    }
}

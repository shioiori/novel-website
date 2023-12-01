using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface IBannerService : IService<BannerDto>
    {
        Task<IEnumerable<BannerDto>> FilterAsync(BannerFilter filter, PagedListRequest request);
        Task<BannerDto> GetByIdAsync(int id);
    }
}
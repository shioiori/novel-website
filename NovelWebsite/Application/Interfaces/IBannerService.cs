using Application.Models.Dtos;
using Application.Models.Filters;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface IBannerService : IService<BannerDto>
    {
        Task<IEnumerable<BannerDto>> FilterAsync(BannerFilter filter, PagedListRequest request);
        Task<BannerDto> GetByIdAsync(int id);
    }
}
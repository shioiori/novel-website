using Application.Models.Dtos;
using Application.Models.Filters;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IBannerService : IService<BannerDto>
    {
        Task<IEnumerable<BannerDto>> FilterAsync(BannerFilter filter);
        Task<BannerDto> GetByIdAsync(int id);
    }
}
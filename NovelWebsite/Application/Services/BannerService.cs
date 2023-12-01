

using Application.Interfaces;
using Application.Models.Dtos;
using Application.Models.Filters;
using Application.Services.Base;
using Application.Utils;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Interfaces;
using System.Linq.Expressions;

namespace NovelWebsite.Application.Services
{
    public class BannerService : GenericService<Banner, BannerDto>, IBannerService
    {
        public BannerService(IBannerRepository bannerRepository, IMapper mapper) : base(bannerRepository, mapper) { }

        public async Task<IEnumerable<BannerDto>> FilterAsync(BannerFilter filter, PagedListRequest request)
        {
            var query = _repository.Get();
            if (filter == null)
            {
                return await MapDtosAsync(query.AsEnumerable());
            }
            if (filter.BannerType != null)
            {
                query = query.Where(x => x.BannerType == (int)filter.BannerType);
            }
            if (filter.ActiveFrom != DateTime.MinValue)
            {
                query = query.Where(x => x.ActiveFrom >= filter.ActiveFrom);
            }
            if (filter.ActiveTo != DateTime.MinValue)
            {
                query = query.Where(x => x.ActiveTo <= filter.ActiveTo);
            }
            var banners = PagedList<Banner>.AsEnumerable(query, request);
            return await MapDtosAsync(banners);
        }

        public async Task<BannerDto> GetByIdAsync(int id)
        {
            var banner = _repository.Get(x => x.BannerId == id).FirstOrDefault();
            return await MapDtoAsync(banner);
        }

    }
}

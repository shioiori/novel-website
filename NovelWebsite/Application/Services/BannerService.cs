

using Application.Models.Dtos;
using Application.Services.Base;
using Application.Utils;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;
using System.Linq.Expressions;

namespace NovelWebsite.Application.Services
{
    public class BannerService : GenericService<Banner, BannerDto>
    {
        public BannerService() : base() { }
        
        public async Task<IEnumerable<BannerDto>> GetBannersByTypeAsync(BannerType type, PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get(x => x.BannerType == (int)type);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(banners);
        }

        public async Task<IEnumerable<BannerDto>> GetActiveBannersByTypeAsync(BannerType type, DateTime dateTime, PagedListRequest pagedListRequest = null) 
        {
            if (dateTime == null || dateTime == DateTime.MinValue)
            {
                dateTime = DateTime.Now;
            }
            Expression<Func<Banner, bool>> expDateTime = x => x.ActiveFrom <= dateTime && x.ActiveTo >= dateTime;
            Expression <Func<Banner, bool>> expType = x => x.BannerType == (int)type;
            var exp = ExpressionCombine<Banner>.And(expDateTime, expType);
            var query = _repository.Get(exp);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(banners);
        }

        public async Task<IEnumerable<BannerDto>> GetAllBannerAsync(PagedListRequest pagedListRequest = null)
        {
            var query = _repository.Get();
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(banners);
        }

        public async Task<IEnumerable<BannerDto>> GetActiveBannersAsync(DateTime dateTime, PagedListRequest pagedListRequest = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            var query = _repository.Get(x => x.ActiveFrom <= dateTime && x.ActiveTo >= dateTime);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return await MapDtosAsync(banners);
        }

        public async Task<BannerDto> GetBannerAsync(object id)
        {
            var banner = await _repository.Get(x => x.BannerId == (int)id).FirstOrDefaultAsync();
            return await MapDtosAsync(banner);
        }

    }
}

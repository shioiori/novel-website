using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Utils;
using System;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BannerService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;
        public BannerService(IBannerRepository bannerRepository, IMapper mapper) 
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }
        
        public IEnumerable<BannerModel> GetBannersByTypeAsync(BannerType type, PagedListRequest pagedListRequest = null)
        {
            var query = _bannerRepository.Filter(x => x.BannerType == (int)type);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetActiveBannersByType(BannerType type, DateTime dateTime, PagedListRequest pagedListRequest = null) 
        {
            if (dateTime == null || dateTime == DateTime.MinValue)
            {
                dateTime = DateTime.Now;
            }
            Expression<Func<Banner, bool>> expDateTime = x => x.ActiveFrom <= dateTime && x.ActiveTo >= dateTime;
            Expression < Func<Banner, bool>> expType = x => x.BannerType == (int)type;
            var exp = ExpressionUtil<Banner>.Combine(expDateTime, expType);
            var query = _bannerRepository.Filter(exp);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetAllBanner(PagedListRequest pagedListRequest = null)
        {
            var query = _bannerRepository.GetAll();
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetActiveBanners(DateTime dateTime, PagedListRequest pagedListRequest = null)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            var query = _bannerRepository.Filter(x => x.ActiveFrom <= dateTime && x.ActiveTo >= dateTime);
            var banners = PagedList<Banner>.AsEnumerable(query, pagedListRequest);
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public async Task<BannerModel> GetBannerAsync(object id)
        {
            var banner = await _bannerRepository.GetByIdAsync(id);
            return _mapper.Map<Banner, BannerModel>(banner);
        }

        public async Task CreateBannerAsync(BannerModel banner)
        {
            await _bannerRepository.InsertAsync(_mapper.Map<BannerModel, Banner>(banner));
            _bannerRepository.SaveAsync();
        }

        public async Task UpdateBannerAsync(BannerModel banner)
        {
           await _bannerRepository.UpdateAsync(_mapper.Map<BannerModel, Banner>(banner));
            _bannerRepository.SaveAsync();

        }

        public async Task DeleteBannerAsync(object bannerId)
        {
            await _bannerRepository.DeleteAsync(bannerId);
            _bannerRepository.SaveAsync();
        }

    }
}

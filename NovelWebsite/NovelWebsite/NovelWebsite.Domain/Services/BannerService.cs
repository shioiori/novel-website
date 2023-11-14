using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Utils;
using System;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;

        Expression<Func<Banner, bool>> expInTime(DateTime dateTime)
        {
            return x => x.ActiveFrom <= dateTime && x.ActiveTo >= dateTime;
        }
        Expression<Func<Banner, bool>> expBannerType(BannerType type)
        {
            return x => x.BannerType == (int)type;

        }
        public BannerService(IBannerRepository bannerRepository, IMapper mapper) 
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }
        
        public IEnumerable<BannerModel> GetBannersByType(BannerType type)
        {
            var banners = _bannerRepository.Filter(expBannerType(type));
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetActiveBannersByType(BannerType type, DateTime dateTime) 
        {
            if (dateTime == null || dateTime == DateTime.MinValue)
            {
                dateTime = DateTime.Now;
            }
            var exp = ExpressionUtil<Banner>.Combine(expBannerType(type), expInTime(dateTime));
            var banners = _bannerRepository.Filter(exp);
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetAllBanner()
        {
            var banners = _bannerRepository.GetAll();
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public IEnumerable<BannerModel> GetActiveBanners(DateTime dateTime)
        {
            if (dateTime == null)
            {
                dateTime = DateTime.Now;
            }
            var banners = _bannerRepository.Filter(expInTime(dateTime));
            return _mapper.Map<IEnumerable<Banner>, IEnumerable<BannerModel>>(banners);
        }

        public BannerModel GetBanner(object id)
        {
            var banner = _bannerRepository.GetById(id);
            return _mapper.Map<Banner, BannerModel>(banner);
        }

        public void CreateBanner(BannerModel banner)
        {
            _bannerRepository.Insert(_mapper.Map<BannerModel, Banner>(banner));
            _bannerRepository.Save();
        }

        public void UpdateBanner(BannerModel banner)
        {
            _bannerRepository.Update(_mapper.Map<BannerModel, Banner>(banner));
            _bannerRepository.Save();

        }

        public void DeleteBanner(object bannerId)
        {
            _bannerRepository.Delete(bannerId);
            _bannerRepository.Save();

        }

    }
}

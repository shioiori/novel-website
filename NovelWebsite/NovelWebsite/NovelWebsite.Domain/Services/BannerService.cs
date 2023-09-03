using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class BannerService : IBannerService
    {
        private readonly IBannerRepository _bannerRepository;
        private readonly IMapper _mapper;

        public BannerService(IBannerRepository bannerRepository, IMapper mapper) 
        {
            _bannerRepository = bannerRepository;
            _mapper = mapper;
        }
        
        public IEnumerable<BannerModel> GetBannersByType(BannerType type)
        {
            var banners = _bannerRepository.Filter(x => x.BannerType == (int)type);
            return _mapper.Map<IEnumerable<BannerEntity>, IEnumerable<BannerModel>>(banners);
        }

    }
}

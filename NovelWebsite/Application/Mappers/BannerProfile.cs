using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class BannerProfile : Profile
    {
        public BannerProfile() {
            CreateMap<BannerDto, Banner>();
            CreateMap<Banner, BannerDto>();
        }
    }
}

using NovelWebsite.Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile() {
            CreateMap<ReviewDto, Review>();
            CreateMap<Review, ReviewDto>();
        }
    }
}

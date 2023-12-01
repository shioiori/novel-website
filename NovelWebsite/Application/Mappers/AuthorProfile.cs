
using NovelWebsite.Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Application.Mappers
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDto, Author>()
                .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.AuthorName) : x.Slug));
            CreateMap<Author, AuthorDto>();
        }
    }
}

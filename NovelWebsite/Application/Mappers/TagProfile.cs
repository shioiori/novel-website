using NovelWebsite.Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class TagProfile : Profile
    {
        public TagProfile() {
            CreateMap<Tag, TagDto>();
            CreateMap<TagDto, Tag>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.TagName) : x.Slug));
        }
    }
}

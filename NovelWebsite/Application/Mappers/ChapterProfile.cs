using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class ChapterProfile : Profile
    {
        public ChapterProfile() {
            CreateMap<ChapterDto, Chapter>()
                        .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.ChapterName) : x.Slug))
                        .ForMember(x => x.ChapterIndex, y => y.MapFrom(x => x.ChapterNumber));

            CreateMap<Chapter, ChapterDto>()
                    .ForMember(x => x.ChapterNumber, y => y.MapFrom(x => x.ChapterIndex));
        }
    }
}

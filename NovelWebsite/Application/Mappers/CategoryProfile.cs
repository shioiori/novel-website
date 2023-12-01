using NovelWebsite.Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile() {

            CreateMap<CategoryDto, Category>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.CategoryName) : x.Slug))
                    .ForMember(x => x.CategoryImage, y => y.NullSubstitute("default.jpg"));
            CreateMap<Category, CategoryDto>();
        }
    }
}

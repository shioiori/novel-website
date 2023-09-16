using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<BannerModel, Banner>();
            CreateMap<Banner, BannerModel>();

            CreateMap<PostModel, Post>();
            CreateMap<Post, PostModel>();

            CreateMap<BookModel, Book>();
            CreateMap<Book, BookModel>();

            CreateMap<ReviewModel, Review>();
            
            CreateMap<RegisterRequest, Account>();
            CreateMap<RegisterRequest, User>();


        }
    }
}

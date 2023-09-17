using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
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
            CreateMap<Review, ReviewModel>();

            CreateMap<RegisterRequest, Account>();
            CreateMap<RegisterRequest, User>();

            CreateMap<RegisterRequest, AccountModel>();
            CreateMap<RegisterRequest, UserModel>();

            CreateMap<AccountModel, Account>();
            CreateMap<Account, AccountModel>();

            CreateMap<UserModel, User>()
                    .ForMember(x => x.Avatar, y => y.NullSubstitute("default.jpg"))
                    .ForMember(x => x.CoverPhoto, y => y.NullSubstitute("default.jpg"))
                    ;
            CreateMap<User, UserModel>();
        }
    }
}

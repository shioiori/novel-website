using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Domain.Utils;
using NovelWebsite.NovelWebsite.Core.Constants;

namespace NovelWebsite.NovelWebsite.Domain.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AuthorModel, Author>()
                .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.AuthorName) : x.Slug));
            CreateMap<Author, AuthorModel>();

            CreateMap<BannerModel, Banner>();
            CreateMap<Banner, BannerModel>();

            CreateMap<BookModel, Book>()
                .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.BookName) : x.Slug))
                .ForMember(x => x.BookStatus, y => y.NullSubstitute(BookStatus.Ongoing));

            CreateMap<Book, BookModel>();

            CreateMap<CategoryModel, Category>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.CategoryName) : x.Slug))
                    .ForMember(x => x.CategoryImage, y => y.NullSubstitute("default.jpg")); 

            CreateMap<Category, CategoryModel>();

            CreateMap<PostModel, Post>();
            CreateMap<Post, PostModel>();

            CreateMap<ReviewModel, Review>();
            CreateMap<Review, ReviewModel>();

            CreateMap<RegisterRequest, User>();
            CreateMap<LoginRequest, User>();

            CreateMap<UserModel, User>()
                    .ForMember(x => x.Avatar, y => y.NullSubstitute("default.jpg"))
                    .ForMember(x => x.CoverPhoto, y => y.NullSubstitute("default.jpg"));
            CreateMap<User, UserModel>();

            CreateMap<Tag, TagModel>();
            CreateMap<TagModel, Tag>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.TagName) : x.Slug));
        }
    }
}

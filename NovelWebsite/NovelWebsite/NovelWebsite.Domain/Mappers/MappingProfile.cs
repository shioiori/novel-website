using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Domain.Utils;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

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

            CreateMap<Book, BookModel>()
                .ForMember(x => x.BookStatus, y => y.MapFrom(x => x.BookStatus == BookStatus.Complete ? "Hoàn thành"
                                                                : (x.BookStatus == BookStatus.Ongoing ? "Còn tiếp"
                                                                : (x.BookStatus == BookStatus.Drop ? "Tạm ngưng" : null))));

            CreateMap<CategoryModel, Category>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.CategoryName) : x.Slug))
                    .ForMember(x => x.CategoryImage, y => y.NullSubstitute("default.jpg")); 
            CreateMap<Category, CategoryModel>();

            CreateMap<ChapterModel, Chapter>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.ChapterName) : x.Slug))
                    .ForMember(x => x.ChapterIndex, y => y.MapFrom(x => x.ChapterNumber));

            CreateMap<Chapter, ChapterModel>()
                    .ForMember(x => x.ChapterNumber, y => y.MapFrom(x => x.ChapterIndex)); 

            CreateMap<PostModel, Post>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.Title) : x.Slug));

            CreateMap<Post, PostModel>();

            CreateMap<ReviewModel, Review>();
            CreateMap<Review, ReviewModel>();

            CreateMap<RegisterRequest, User>();
            CreateMap<LoginRequest, User>();

            CreateMap<RoleModel, Role>()
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.RoleId))
                    .ForMember(x => x.Name, y => y.MapFrom(x => x.RoleName));
            CreateMap<Role, RoleModel>()
                    .ForMember(x => x.RoleId, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.RoleName, y => y.MapFrom(x => x.Name));
            CreateMap<string, RoleModel>()
                    .ForMember(x => x.RoleName, y => y.MapFrom(x => x));

            CreateMap<UserModel, User>()
                    .ForMember(x => x.Avatar, y => y.NullSubstitute("default.jpg"))
                    .ForMember(x => x.CoverPhoto, y => y.NullSubstitute("default.jpg"))
                    .ForMember(x => x.UserName, y => y.MapFrom(x => x.Username))
                    .ForMember(x => x.CreatedDate, y => y.NullSubstitute(DateTime.Now))
                    .ForMember(x => x.Id, y => y.MapFrom(x => x.UserId));

            CreateMap<User, UserModel>()
                    .ForMember(x => x.Username, y => y.MapFrom(x => x.UserName))
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.Id));

            CreateMap<Tag, TagModel>();
            CreateMap<TagModel, Tag>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugifyUtil.Slugify(x.TagName) : x.Slug));
        }
    }
}

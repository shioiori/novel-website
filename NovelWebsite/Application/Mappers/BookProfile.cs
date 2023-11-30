using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Constants;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace Application.Mappers
{
    public class BookProfile : Profile
    {
        public BookProfile() {

            CreateMap<BookDto, Book>()
                .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.BookName) : x.Slug))
                .ForMember(x => x.BookStatus, y => y.NullSubstitute(BookStatus.Ongoing));

            CreateMap<Book, BookDto>()
                .ForMember(x => x.BookStatus, y => y.MapFrom(x => x.BookStatus == BookStatus.Complete ? "Hoàn thành"
                                                                : (x.BookStatus == BookStatus.Ongoing ? "Còn tiếp"
                                                                : (x.BookStatus == BookStatus.Drop ? "Tạm ngưng" : null))))
                .ForPath(x => x.StatusLabel.Name, y => y.MapFrom(x => x.Status == (int)UploadStatus.Draft ? "Bản nháp"
                                                                : (x.Status == (int)UploadStatus.Moderation ? "Chờ duyệt"
                                                                : (x.Status == (int)UploadStatus.Denied ? "Từ chối"
                                                                : (x.Status == (int)UploadStatus.Publish ? "Xuất bản" : null)))))
                .ForPath(x => x.StatusLabel.Color, y => y.MapFrom(x => x.Status == (int)UploadStatus.Draft ? "default"
                                                                : (x.Status == (int)UploadStatus.Moderation ? "warning"
                                                                : (x.Status == (int)UploadStatus.Denied ? "danger"
                                                                : (x.Status == (int)UploadStatus.Publish ? "success" : null)))));

        }
    }
}

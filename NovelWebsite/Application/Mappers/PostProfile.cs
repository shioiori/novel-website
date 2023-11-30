using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace Application.Mappers
{
    internal class PostProfile : Profile
    {
        public PostProfile() {
            CreateMap<PostDto, Post>()
                    .ForMember(x => x.Slug, y => y.MapFrom(x => string.IsNullOrEmpty(x.Slug) ? SlugConverter.Slugify(x.Title) : x.Slug));
            CreateMap<Post, PostDto>()
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

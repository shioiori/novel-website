using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Enums;

namespace Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile() {
            CreateMap<UserDto, User>()
                        .ForMember(x => x.Avatar, y => y.NullSubstitute("default.jpg"))
                        .ForMember(x => x.CoverPhoto, y => y.NullSubstitute("default.jpg"))
                        .ForMember(x => x.UserName, y => y.MapFrom(x => x.Username))
                        .ForMember(x => x.CreatedDate, y => y.NullSubstitute(DateTime.Now))
                        .ForMember(x => x.Id, y => y.MapFrom(x => x.UserId));

            CreateMap<User, UserDto>()
                    .ForMember(x => x.Username, y => y.MapFrom(x => x.UserName))
                    .ForMember(x => x.UserId, y => y.MapFrom(x => x.Id))
                    .ForPath(x => x.StatusLabel.Name, y => y.MapFrom(x => x.Status == (int)AccountStatus.Verifying ? "Chưa xác nhận"
                                                                    : (x.Status == (int)AccountStatus.Active ? "Hoạt động"
                                                                    : (x.Status == (int)AccountStatus.Banned ? "Chặn" : null))))
                    .ForPath(x => x.StatusLabel.Color, y => y.MapFrom(x => x.Status == (int)AccountStatus.Verifying ? "warning"
                                                                    : (x.Status == (int)AccountStatus.Active ? "success"
                                                                    : (x.Status == (int)AccountStatus.Banned ? "danger" : null))));
        }
    }
}

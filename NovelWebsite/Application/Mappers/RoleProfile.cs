using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class RoleProfile : Profile
    {
        public RoleProfile() {
            CreateMap<RoleDto, Role>()
                          .ForMember(x => x.Name, y => y.MapFrom(x => x.RoleName));
            CreateMap<Role, RoleDto>()
                    .ForMember(x => x.RoleId, y => y.MapFrom(x => x.Id))
                    .ForMember(x => x.RoleName, y => y.MapFrom(x => x.Name));
            CreateMap<string, RoleDto>()
                    .ForMember(x => x.RoleName, y => y.MapFrom(x => x));
        }
    }
}

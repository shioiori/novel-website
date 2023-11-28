using Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Application.Models.Request;

namespace Application.Mappers.Request
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile() {
            CreateMap<RegisterRequest, UserDto>();
            CreateMap<LoginRequest, UserDto>();
        }
    }
}

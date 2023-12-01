using NovelWebsite.Application.Models.Dtos;
using AutoMapper;
using NovelWebsite.Domain.Entities;

namespace Application.Mappers
{
    public class CommentProfile : Profile { 
        public CommentProfile() {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}

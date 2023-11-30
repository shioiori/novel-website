using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IPostService : IService<PostDto>
    {
        Task<IEnumerable<PostDto>> FilterAsync(PostFilter filter);
        Task<PostDto> GetByIdAsync(string postId);
    }
}
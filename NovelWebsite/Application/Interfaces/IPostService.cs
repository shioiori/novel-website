using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface IPostService : IService<PostDto>
    {
        Task<IEnumerable<PostDto>> FilterAsync(PostFilter filter, PagedListRequest request);
        Task<PostDto> GetByIdAsync(string postId);
    }
}
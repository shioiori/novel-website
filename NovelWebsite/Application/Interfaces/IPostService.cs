using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface IPostService : IService<PostDto>
    {
        Task<IEnumerable<PostDto>> FilterAsync(PostFilter filter, PagedListRequest request);
        Task<PostDto> GetByIdAsync(string postId);
    }
}
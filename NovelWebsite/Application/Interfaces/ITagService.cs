using Application.Models.Dtos;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface ITagService : IService<TagDto>
    {
        Task AddOfBookAsync(string bookId, IEnumerable<int> tags);
        Task<IEnumerable<TagDto>> GetAllAsync(PagedListRequest pagedListRequest = null);
        Task<TagDto> GetByIdAsync(int tagId);
        Task<TagDto> GetByNameAsync(string name);
        Task<TagDto> GetBySlugAsync(string slug);
        Task<IEnumerable<TagDto>> GetOfBookAsync(string bookId);
    }
}
using Application.Models.Dtos;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface IAuthorService : IService<AuthorDto>
    {
        Task<IEnumerable<AuthorDto>> GetAllAsync(PagedListRequest pagedListRequest = null);
        Task<AuthorDto> GetByIdAsync(int id);
        Task<AuthorDto> GetByNameAsync(string name);
        Task<AuthorDto> GetBySlugAsync(string slug);
    }
}
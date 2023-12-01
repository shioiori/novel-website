using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface ICategoryService : IService<CategoryDto>
    {
        Task<IEnumerable<CategoryDto>> GetAllAsync(PagedListRequest pagedListRequest = null);
        Task<CategoryDto> GetByIdAsync(int categoryId);
        Task<CategoryDto> GetByNameAsync(string name);
        Task<CategoryDto> GetBySlugAsync(string slug);
    }
}
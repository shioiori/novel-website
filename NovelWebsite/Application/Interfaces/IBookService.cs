using NovelWebsite.Application.Models.Dtos;
using NovelWebsite.Application.Models.Filters;
using NovelWebsite.NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Requests;

namespace NovelWebsite.Application.Interfaces
{
    public interface IBookService : IService<BookDto>
    {
        Task<IEnumerable<BookDto>> FilterAsync(BillboardFilter filter, PagedListRequest request);
        Task<IEnumerable<BookDto>> FilterAsync(BookFilter filter, PagedListRequest request);
        Task<BookDto> GetByIdAsync(string id);
    }
}
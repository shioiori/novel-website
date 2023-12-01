using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;

namespace Application.Interfaces
{
    public interface IBookService : IService<BookDto>
    {
        Task<IEnumerable<BookDto>> FilterAsync(BillboardFilter filter, PagedListRequest request);
        Task<IEnumerable<BookDto>> FilterAsync(BookFilter filter, PagedListRequest request);
        Task<BookDto> GetByIdAsync(string id);
    }
}
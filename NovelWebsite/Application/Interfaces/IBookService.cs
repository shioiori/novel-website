using Application.Models.Dtos;
using Application.Models.Filter;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IBookService : IService<BookDto>
    {
        Task<IEnumerable<BookDto>> FilterAsync(BillboardFilter filter);
        Task<IEnumerable<BookDto>> FilterAsync(BookFilter filter);
        Task<BookDto> GetByIdAsync(string id);
    }
}
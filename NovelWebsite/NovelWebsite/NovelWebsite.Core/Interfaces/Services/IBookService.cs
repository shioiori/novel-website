using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBookService : IService<BookModel>
    {
        void DeleteTemporary(string bookId);
        BookModel GetById(string bookId);
        IEnumerable<BookModel> GetByUserInteractive(InteractionType type);
        IEnumerable<BookModel> GetAll();
        IEnumerable<BookModel> GetByAuthor(int authorId);
        IEnumerable<BookModel> GetByBookStatus(string status);
        IEnumerable<BookModel> GetByCategory(int categoryId);
        IEnumerable<BookModel> GetByFilter(FilterModel filter);
        IEnumerable<BookModel> GetFromTime(DateTime start);
    }

}

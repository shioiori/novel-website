using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBookService
    {
        void CreateBook(BookModel book);
        void UpdateBook(BookModel book);
        void DeleteBook(int bookId);
        void DeleteBookPermanent(int bookId);
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetBook(int bookId);
        IEnumerable<BookModel> GetBookByFilter(FilterModel filter);
        IEnumerable<BookModel> GetBooks();

    }
}

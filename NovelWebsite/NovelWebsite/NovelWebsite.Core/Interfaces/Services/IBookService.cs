using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBookService
    {
        void CreateBook(BookModel book);
        void DeleteBook(int bookId);
        void DeleteBookPermanent(int bookId);
        IEnumerable<BookModel> GetAllBooks();
        BookModel GetBook(int bookId);
        IEnumerable<BookModel> GetBookByUserInteractive(InteractionType type);
        IEnumerable<BookModel> GetBooks();
        IEnumerable<BookModel> GetBooksByAuthor(int authorId);
        IEnumerable<BookModel> GetBooksByBookStatus(string status);
        IEnumerable<BookModel> GetBooksByCategory(int categoryId);
        IEnumerable<BookModel> GetBooksByFilter(FilterModel filter);
        IEnumerable<BookModel> GetBooksFromTime(DateTime start);
        void UpdateBook(BookModel book);
    }

}

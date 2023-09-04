using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IBookService
    {
        IEnumerable<BookModel> GetValidBooks();
        IEnumerable<BookModel> GetValidBooksByAuthor(int authorId);
        IEnumerable<BookModel> GetValidBooksByCategory(int categoryId);

    }
}

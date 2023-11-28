using Domain.Interfaces.Base;
using NovelWebsite.Domain.Entities;
using System.Linq.Expressions;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        //IEnumerable<BookEntity> GetBooksByAuthor(int authorId);
        //IEnumerable<BookEntity> GetBooksByUserUpload(int userId);
        //IEnumerable<BookEntity> GetBooksByCategory(int categoryId);
        //IEnumerable<BookEntity> GetBooksFinished();

    }
}

using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Linq.Expressions;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        //IEnumerable<BookEntity> GetBooksByAuthor(int authorId);
        //IEnumerable<BookEntity> GetBooksByUserUpload(int userId);
        //IEnumerable<BookEntity> GetBooksByCategory(int categoryId);
        //IEnumerable<BookEntity> GetBooksFinished();

    }
}

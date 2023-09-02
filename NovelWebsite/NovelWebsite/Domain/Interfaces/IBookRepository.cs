using NovelWebsite.Infrastructure.Entities;
using System.Linq.Expressions;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IBookRepository : IGenericRepository<BookEntity>
    {
        IEnumerable<BookEntity> GetBooksByAuthor(int authorId);
        IEnumerable<BookEntity> GetBooksByUserUpload(int userId);
        IEnumerable<BookEntity> GetBooksByCategory(int categoryId);
        IEnumerable<BookEntity> GetBooksFinished();

    }
}

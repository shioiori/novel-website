using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using System.Linq.Expressions;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        Expression<Func<BookEntity, object>> sortType = x => x.GetType().GetProperty("PropertyName");

        public BookRepository(AppDbContext dbContext) : base(dbContext) { }

        public IEnumerable<BookEntity> GetBooksByAuthor(int authorId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEntity> GetBooksByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEntity> GetBooksByUserUpload(int userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookEntity> GetBooksFinished()
        {
            throw new NotImplementedException();
        }
    }
}

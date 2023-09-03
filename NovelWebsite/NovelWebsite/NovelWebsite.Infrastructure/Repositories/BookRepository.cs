using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces;
using System.Linq.Expressions;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class BookRepository : GenericRepository<BookEntity>, IBookRepository
    {
        Expression<Func<BookEntity, object>> sortType = x => x.GetType().GetProperty("PropertyName");

        public BookRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}

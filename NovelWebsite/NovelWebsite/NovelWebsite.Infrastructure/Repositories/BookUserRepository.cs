using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookUserRepository : GenericRepository<Book_User>
    {
        public BookUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

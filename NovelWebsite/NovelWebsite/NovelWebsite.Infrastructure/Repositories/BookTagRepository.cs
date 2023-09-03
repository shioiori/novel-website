using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookTagRepository : GenericRepository<Book_Tag>
    {
        public BookTagRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

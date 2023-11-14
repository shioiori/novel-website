using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BookTagRepository : GenericRepository<BookTags>, IBookTagRepository
    {
        public BookTagRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

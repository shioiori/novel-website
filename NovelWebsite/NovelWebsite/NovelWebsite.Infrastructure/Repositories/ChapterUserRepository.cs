using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ChapterUserRepository : GenericRepository<ChapterUser>
    {
        public ChapterUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

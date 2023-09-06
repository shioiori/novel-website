using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ChapterUserRepository : GenericRepository<Chapter_User>, IChapterUserRepository
    {
        public ChapterUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

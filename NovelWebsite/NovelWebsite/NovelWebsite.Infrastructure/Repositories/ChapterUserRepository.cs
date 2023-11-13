using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ChapterUserRepository : GenericRepository<ChapterUsers>, IChapterUserRepository
    {
        public ChapterUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

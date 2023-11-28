using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class ChapterRepository : GenericRepository<Chapter>, IChapterRepository
    {
        public ChapterRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

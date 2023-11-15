using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ReviewUserRepository : GenericRepository<ReviewUsers>, IReviewUserRepository
    {
        public ReviewUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

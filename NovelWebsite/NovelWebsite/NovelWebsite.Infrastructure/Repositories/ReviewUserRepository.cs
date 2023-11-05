using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ReviewUserRepository : GenericRepository<Review_User>, IReviewUserRepository
    {
        public ReviewUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

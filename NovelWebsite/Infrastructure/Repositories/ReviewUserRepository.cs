using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class ReviewUserRepository : GenericRepository<ReviewUsers>, IReviewUserRepository
    {
        public ReviewUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

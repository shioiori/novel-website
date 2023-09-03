using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class ReviewUserRepository : GenericRepository<Review_User>
    {
        public ReviewUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

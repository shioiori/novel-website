using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class BannerRepository : GenericRepository<BannerEntity>, IBannerRepository
    {
        public BannerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

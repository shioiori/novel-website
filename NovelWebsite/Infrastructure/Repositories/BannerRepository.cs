using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class BannerRepository : GenericRepository<Banner>, IBannerRepository
    {
        public BannerRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

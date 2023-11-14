using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class PostUserRepository : GenericRepository<PostUsers>, IPostUserRepository
    {
        public PostUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

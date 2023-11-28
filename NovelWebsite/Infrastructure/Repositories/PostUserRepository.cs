using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class PostUserRepository : GenericRepository<PostUsers>, IPostUserRepository
    {
        public PostUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

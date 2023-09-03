using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class PostUserRepository : GenericRepository<Post_User>
    {
        public PostUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

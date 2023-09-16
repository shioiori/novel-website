using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Infrastructure.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class CommentUserRepository : GenericRepository<Comment_User>, ICommentUserRepository
    {
        public CommentUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

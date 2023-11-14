using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class CommentUserRepository : GenericRepository<CommentUsers>, ICommentUserRepository
    {
        public CommentUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

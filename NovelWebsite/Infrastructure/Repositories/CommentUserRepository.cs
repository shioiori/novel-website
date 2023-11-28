using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class CommentUserRepository : GenericRepository<CommentUsers>, ICommentUserRepository
    {
        public CommentUserRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}

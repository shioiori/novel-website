using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}

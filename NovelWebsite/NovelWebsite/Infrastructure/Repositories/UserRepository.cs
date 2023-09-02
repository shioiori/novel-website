using NovelWebsite.Domain.Interfaces;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
    }
}

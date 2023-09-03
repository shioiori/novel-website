using System.Linq.Expressions;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
        public User IfExistsUser(Expression<Func<User, bool>> expression){
            return _table.FirstOrDefault(expression);
        }
    }
}

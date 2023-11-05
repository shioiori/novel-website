using System.Linq;
using System.Linq.Expressions;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext dbContext) : base(dbContext) { }
        public User IfExistsUser(Expression<Func<User, bool>> expression){
            return _table.FirstOrDefault(expression);
        }

        public User GetUserByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }

        public User GetUserByUsername(string username)
        {
            //return _table.FirstOrDefault(x => x.Username == username);
            throw new NotImplementedException();
        }
    }
}

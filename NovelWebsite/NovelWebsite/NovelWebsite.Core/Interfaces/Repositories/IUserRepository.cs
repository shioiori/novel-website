using System.Linq.Expressions;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User IfExistsUser(Expression<Func<User, bool>> expression);
        User GetUserByEmail(string email);
        User GetUserByUsername(string username);
    }
}

using System.Linq;
using System.Linq.Expressions;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class UserRoleRepository : GenericRepository<User_Role>, IUserRoleRepository
    {
        public UserRoleRepository(AppDbContext dbContext) : base(dbContext) { }

        public void Delete(int userId, int roleId)
        {
            var user_role = _table.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);
            _table.Remove(user_role);
        }

        public User_Role GetById(int userId, int roleId)
        {
            return _table.FirstOrDefault(x => x.UserId == userId && x.RoleId == roleId);
        }
    }
}

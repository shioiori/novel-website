using System.Linq;
using System.Linq.Expressions;
using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Infrastructure.Repositories
{
    public class RolePermissionRepository : GenericRepository<RolePermissions>, IRolePermissionRepository
    {
        public RolePermissionRepository(AppDbContext dbContext) : base(dbContext) { }

        public void Delete(string roleId, int perId)
        {
            var rolePer = _table.FirstOrDefault(x => x.RoleId == roleId && x.PermissionId == perId);
            _table.Remove(rolePer);
        }

        public RolePermissions GetById(string roleId, int perId)
        {
            return _table.FirstOrDefault(x => x.RoleId == roleId && x.PermissionId == perId);
        }
    }
}

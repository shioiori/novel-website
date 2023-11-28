using NovelWebsite.Infrastructure.Contexts;
using NovelWebsite.Infrastructure.Repositories.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;

namespace NovelWebsite.Infrastructure.Repositories
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

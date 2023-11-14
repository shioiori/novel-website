using NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermissions>
    {
        void Delete(int roleId, int perId);
        RolePermissions GetById(int roleId, int perId);
    }
}

using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermissions>
    {
        void Delete(string roleId, int perId);
        RolePermissions GetById(string roleId, int perId);
    }
}

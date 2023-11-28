using Domain.Interfaces.Base;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Domain.Interfaces
{
    public interface IRolePermissionRepository : IGenericRepository<RolePermissions>
    {
        void Delete(string roleId, int perId);
        RolePermissions GetById(string roleId, int perId);
    }
}

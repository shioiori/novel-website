using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleModel> GetRoles();
        void Add(RoleModel role);
        void Update(RoleModel role);
        void Delete(int roleId);
        void SetPermissionToRole(int roleId, int perId);
        void RemovePermissionToRole(int roleId, int perId);
    }
}

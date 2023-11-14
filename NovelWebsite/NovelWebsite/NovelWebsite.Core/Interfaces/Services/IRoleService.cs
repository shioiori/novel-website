using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleModel> GetRoles();
        void Add(RoleModel role);
        void Update(RoleModel role);
        void Delete(string roleId);
        void SetPermissionToRole(string roleId, int perId);
        void RemovePermissionToRole(string roleId, int perId);
    }
}

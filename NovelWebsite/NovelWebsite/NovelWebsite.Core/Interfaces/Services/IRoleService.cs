using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IRoleService
    {
        IEnumerable<RoleModel> GetRoles();
        Task AddAsync(RoleModel role);
        Task UpdateAsync(RoleModel role);
        Task DeleteAsync(string name);
        void SetPermissionToRole(string roleId, int perId);
        void RemovePermissionToRole(string roleId, int perId);
        Task<IEnumerable<RoleModel>> GetUserRole(string username);
    }
}

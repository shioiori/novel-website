using NovelWebsite.NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IRolePermissionRepository : IGenericRepository<Role_Permission>
    {
        void Delete(int roleId, int perId);
        Role_Permission GetById(int roleId, int perId);
    }
}

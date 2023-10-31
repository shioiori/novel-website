using NovelWebsite.Infrastructure.Entities;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Repositories
{
    public interface IUserRoleRepository: IGenericRepository<User_Role>
    {
        User_Role GetById(int userId, int roleId);
        void Delete(int userId, int roleId);
    }
}

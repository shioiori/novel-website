using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IUserService
    {
        void CreateUser(UserModel model);
        void DeleteUser(int id);
        UserModel GetCurrentUser();
        UserModel GetUserById(int id);
        IEnumerable<UserModel> GetUsers();
        IEnumerable<UserModel> GetUsersByRole(int roleId);
        void UpdateUser(UserModel model);
        void SetUserStatus(int userId, int status);

        void SetUserRole(int userId, int roleId);

        void RemoveUserRole(int userId, int roleId);
    }
}

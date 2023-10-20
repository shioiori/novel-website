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
        void UpdateUser(UserModel model);
    }
}

using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IUserService
    {
        void CreateUser(UserModel model);
        Task DeleteAsync(string userId);
        void DeleteUser(UserModel model);
        Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal principal);
        Task<UserModel> GetUserByIdAsync(string id);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<IEnumerable<UserModel>> GetUsersByRole(string roleId);
        Task SetUserStatusAsync(string userId, int status);
        void UpdateUser(UserModel model);
    }
}

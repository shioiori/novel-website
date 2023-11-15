using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task CreateUserAsync(UserModel model);
        Task DeleteAsync(string userId);
        void DeleteUser(UserModel model);
        Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal principal);
        Task<UserModel> GetUserByIdAsync(string id);
        Task<UserModel> GetUserByUsernameAsync(string username);
        Task<UserModel> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserModel>> GetUsers();
        Task<IEnumerable<UserModel>> GetUsersByRole(string roleId);
        Task SetUserStatusAsync(string userId, int status);
        Task UpdateUserAsync(UserModel model);
    }
}

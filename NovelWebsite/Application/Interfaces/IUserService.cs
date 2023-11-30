using Application.Models.Dtos;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Models.Request;
using System.Security.Claims;

namespace Application.Interfaces
{
    public interface IUserService : IService<UserDto>
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByEmailAsync(string email);
        Task<UserDto> GetByIdAsync(string id);
        Task<UserDto> GetByUsernameAsync(string username);
        Task<IEnumerable<UserDto>> GetByRoleAsync(string role, PagedListRequest request);
        Task<IEnumerable<UserDto>> GetByStatusAsync(int status, PagedListRequest request);
        Task<UserDto> GetCurrentAsync(ClaimsPrincipal principal);
        Task RemoveRoleAsync(string username, string role);
        Task SetRoleAsync(string username, string role);
        Task SetStatusAsync(string userId, int status);
    }
}
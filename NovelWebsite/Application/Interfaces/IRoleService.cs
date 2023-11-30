using Application.Models.Dtos;
using NovelWebsite.Application.Interfaces;

namespace Application.Interfaces
{
    public interface IRoleService : IService<RoleDto>
    {
        Task<IEnumerable<RoleDto>> GetAllAsync();
        Task<RoleDto> GetByNameAsync(string name);
        Task<IEnumerable<RoleDto>> GetOfUserAsync(string name);
        Task RemovePermission(string roleId, int perId);
        Task SetPermission(string roleId, int perId);
    }
}
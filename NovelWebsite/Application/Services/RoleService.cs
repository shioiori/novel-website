using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.Application.Interfaces.Services;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Data;
using Microsoft.AspNetCore.Identity;
using NovelWebsite.Application.Constants;
using Application.Models.Dtos;

namespace NovelWebsite.Application.Services
{
    public class RoleService 
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository,
                            RoleManager<Role> roleManager,
                            UserManager<User> userManager,
                            IMapper mapper) 
        { 
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<RoleDto> GetRole(string name)
        {
            if (await _roleManager.RoleExistsAsync(name))
            {
                var role = await _roleManager.FindByNameAsync(name);
                return _mapper.Map<Role, RoleDto>(role);
            }
            return null;
        }
        public async Task AddAsync(RoleDto model)
        {
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = model.RoleName,
                });
            }
        }
        
        public async Task UpdateAsync(RoleDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
        }

        public async Task DeleteAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            if (role == null)
            {
                role = await _roleManager.FindByIdAsync(name);
                if (role == null) return;
            }
            await _roleManager.DeleteAsync(role);
        }

        public IEnumerable<RoleDto> GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleDto>>(roles);
        }

        public void RemovePermissionToRole(string roleId, int perId)
        {
            var rolePers = _rolePermissionRepository.GetById(roleId, perId);
            _rolePermissionRepository.Delete(roleId, perId);
        }

        public void SetPermissionToRole(string roleId, int perId)
        {
            _rolePermissionRepository.InsertAsync(new RolePermissions()
            {
                RoleId = roleId,
                PermissionId = perId
            });
            _rolePermissionRepository.SaveAsync();
        }

        public async Task<IEnumerable<RoleDto>> GetUserRole(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            var roles = await _userManager.GetRolesAsync(user);
            return _mapper.Map<IEnumerable<string>, IEnumerable<RoleDto>>(roles);
        }
    }
}

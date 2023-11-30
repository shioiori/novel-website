using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class RoleService : GenericService<Role, RoleDto>, IRoleService
    {
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public RoleService(IRoleRepository roleRepository,
                        IRolePermissionRepository rolePermissionRepository,
                        RoleManager<Role> roleManager,
                        UserManager<User> userManager,
                        IMapper mapper) : base(roleRepository, mapper)
        {
            //_roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<RoleDto> GetByNameAsync(string name)
        {
            if (await _roleManager.RoleExistsAsync(name))
            {
                var role = await _roleManager.FindByNameAsync(name);
                return _mapper.Map<Role, RoleDto>(role);
            }
            return null;
        }

        public async Task<IEnumerable<RoleDto>> GetAllAsync()
        {
            var roles = _roleManager.Roles.ToList();
            return await MapDtosAsync(roles);
        }

        public async Task<IEnumerable<RoleDto>> GetOfUserAsync(string name)
        {
            var user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(name);
            }
            if (user == null)
            {
                user = await _userManager.FindByIdAsync(name);
            }
            if (user == null)
            {
                throw new Exception("No user existed");
            }
            var roles = await _userManager.GetRolesAsync(user);
            return _mapper.Map<IEnumerable<string>, IEnumerable<RoleDto>>(roles);
        }

        public Task RemovePermission(string roleId, int perId)
        {
            var rolePers = _rolePermissionRepository.GetById(roleId, perId);
            _rolePermissionRepository.Delete(roleId, perId);
            return Task.CompletedTask;
        }

        public Task SetPermission(string roleId, int perId)
        {
            _rolePermissionRepository.InsertAsync(new RolePermissions()
            {
                RoleId = roleId,
                PermissionId = perId
            });
            _rolePermissionRepository.SaveAsync();
            return Task.CompletedTask;
        }

        public override async Task<RoleDto> AddAsync(RoleDto model)
        {
            if (!await _roleManager.RoleExistsAsync(model.RoleName))
            {
                var res = await _roleManager.CreateAsync(new Role()
                {
                    Name = model.RoleName,
                });
                if (res.Succeeded)
                {
                    return await MapDtoAsync(await _roleManager.FindByNameAsync(model.RoleName));
                }
                else
                {
                    throw new Exception("Add failed");
                }
            }
            else
            {
                throw new Exception("Role is existed");
            }
        }

        public override async Task<RoleDto> UpdateAsync(RoleDto model)
        {
            var role = await _roleManager.FindByIdAsync(model.RoleId);
            return await MapDtoAsync(role);
        }

        public override async Task DeleteAsync(object name)
        {
            var role = await _roleManager.FindByNameAsync(name.ToString());
            if (role == null)
            {
                role = await _roleManager.FindByIdAsync(name.ToString());
                if (role == null) return;
            }
            await _roleManager.DeleteAsync(role);
        }

    }
}

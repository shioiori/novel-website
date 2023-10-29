using AutoMapper;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.Data;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IRolePermissionRepository _rolePermissionRepository;
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IRolePermissionRepository rolePermissionRepository,
                            IMapper mapper) 
        { 
            _roleRepository = roleRepository;
            _rolePermissionRepository = rolePermissionRepository;
            _mapper = mapper;
        }
        public void Add(RoleModel role)
        {
            _roleRepository.Insert(_mapper.Map<RoleModel, Role>(role));
            _roleRepository.Save();
        }
        
        public void Update(RoleModel role)
        {
            _roleRepository.Update(_mapper.Map<RoleModel, Role>(role));
            _roleRepository.Save();
        }

        public void Delete(int roleId)
        {
            _roleRepository.Delete(roleId);
            _roleRepository.Save();
        }

        public IEnumerable<RoleModel> GetRoles()
        {
            var roles = _roleRepository.GetAll();
            return _mapper.Map<IEnumerable<Role>, IEnumerable<RoleModel>>(roles);
        }

        public void RemovePermissionToRole(int roleId, int perId)
        {
            var rolePers = _rolePermissionRepository.GetById(roleId, perId);
            _rolePermissionRepository.Delete(roleId, perId);
        }

        public void SetPermissionToRole(int roleId, int perId)
        {
            _rolePermissionRepository.Insert(new Role_Permission()
            {
                RoleId = roleId,
                PermissionId = perId
            });
            _rolePermissionRepository.Save();
        }

    }
}

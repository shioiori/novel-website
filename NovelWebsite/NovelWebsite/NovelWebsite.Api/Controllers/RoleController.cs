using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) 
        { 
            _roleService = roleService;
        }

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<RoleModel> GetAll()
        {
            return _roleService.GetRoles();
        }

        [HttpPost]
        [Route("add")]
        public void Add(RoleModel model) {
            _roleService.Add(model);
        }

        [HttpPost]
        [Route("update")]
        public void Update(RoleModel model) {
            _roleService.Update(model);
        }

        [HttpDelete]
        [Route("delete")]
        public void Delete(int id) {
            _roleService.Delete(id);
        }


        [HttpPut]
        [Route("set-permission")] 
        public void SetPermission(int roleId, int permissionId)
        {
            _roleService.SetPermissionToRole(roleId, permissionId);
        }


        [HttpPut]
        [Route("remove-permission")]
        public void RemovePermission(int roleId, int permissionId) 
        { 
            _roleService.RemovePermissionToRole(roleId, permissionId);
        }

    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
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
        public void Delete(string id) {
            _roleService.Delete(id);
        }


        [HttpPut]
        [Route("set-permission")] 
        public void SetPermission(string roleId, int permissionId)
        {
            _roleService.SetPermissionToRole(roleId, permissionId);
        }


        [HttpPut]
        [Route("remove-permission")]
        public void RemovePermission(string roleId, int permissionId) 
        { 
            _roleService.RemovePermissionToRole(roleId, permissionId);
        }

    }
}

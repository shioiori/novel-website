using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Domain.Services;
using System.Security.Claims;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("/role")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly RoleService _roleService;
        public RoleController(RoleService roleService) 
        { 
            _roleService = roleService;
        }

        [HttpGet]
        [Route("get-all")]
        public IEnumerable<RoleModel> GetAll()
        {
            return _roleService.GetRoles();
        }

        [HttpGet]
        [Route("get-role")]
        public async Task<IEnumerable<RoleModel>> GetUserRoleAsync(string username)
        {
            if (username == null)
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }
            return await _roleService.GetUserRole(username);
        }

        [HttpPost]
        [Route("add")]
        //[Authorize(Roles = "Host")]
        public async Task AddAsync(RoleModel model) {
            await _roleService.AddAsync(model);
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Host")]
        public async Task UpdateAsync(RoleModel model) {
            await _roleService.UpdateAsync(model);
        }

        [HttpDelete]
        [Route("delete")]
        [Authorize(Roles = "Host")]
        public async Task DeleteAsync(string id) {
            await _roleService.DeleteAsync(id);
        }


        [HttpPut]
        [Route("set-permission")]
        [Authorize(Roles = "Host")]
        public void SetPermission(string roleId, int permissionId)
        {
            _roleService.SetPermissionToRole(roleId, permissionId);
        }


        [HttpPut]
        [Route("remove-permission")]
        [Authorize(Roles = "Host")]
        public void RemovePermission(string roleId, int permissionId) 
        { 
            _roleService.RemovePermissionToRole(roleId, permissionId);
        }

    }
}

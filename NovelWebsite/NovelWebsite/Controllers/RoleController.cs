using Application.Interfaces;
using Application.Models.Dtos;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Controllers.Base;
using System.Security.Claims;

namespace NovelWebsite.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    [Route("/role")]
    [ApiController]
    public class RoleController : BaseController<RoleDto>
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService) : base(roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var roles = await _roleService.GetAllAsync();
                return Ok(PagedList<RoleDto>.ToPagedList(roles));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetOfUserAsync(string? username)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    username = identity.FindFirst(ClaimTypes.Name).Value;
                }
                var roles = await _roleService.GetOfUserAsync(username);
                return Ok(PagedList<RoleDto>.ToPagedList(roles));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            try
            {
                var role = await _roleService.GetByNameAsync(name);
                return Ok(role);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("set/permission")]
        public async Task<IActionResult> SetPermissionAsync(string rid, int pid)
        {
            try
            {
                await _roleService.SetPermission(rid, pid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("remove/permission")]
        public async Task<IActionResult> GetByNameAsync(string rid, int pid)
        {
            try
            {
                await _roleService.SetPermission(rid, pid);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

using Application.Interfaces;
using Application.Models.Dtos;
using Application.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Services;
using NovelWebsite.Controllers.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Services;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Security.Claims;
using System.Xml.Linq;
using static IdentityServer4.Models.IdentityResources;

namespace NovelWebsite.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : BaseController<UserDto>
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) : base(userService)
        {
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet("")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();
                return Ok(PagedList<UserDto>.ToPagedList(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(string id)
        {
            try
            {
                var user = await _userService.GetByIdAsync(id);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetByNameAsync(string username)
        {
            try
            {
                var user = await _userService.GetByUsernameAsync(username);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetByEmailAsync(string email)
        {
            try
            {
                var user = await _userService.GetByEmailAsync(email);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet("{role}")]
        public async Task<IActionResult> GetByRoleAsync(string role, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var users = await _userService.GetByRoleAsync(role, request);
                return Ok(PagedList<UserDto>.ToPagedList(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet("{status}")]
        public async Task<IActionResult> GetByStatusAsync(int status, [FromQuery] PagedListRequest? request)
        {
            try
            {
                var users = await _userService.GetByStatusAsync(status, request);
                return Ok(PagedList<UserDto>.ToPagedList(users));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin, Host")]
        [HttpPut]
        [Route("set/status")]
        public async Task<IActionResult> SetStatusAsync(string? username, string? email, string? id, int status)
        {
            try
            {
                if (username == null && email == null && id == null)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    username = identity.FindFirst(ClaimTypes.Name).Value;
                }
                else
                {
                    if (email != null)
                    {
                        username = email;
                    }
                    if (id != null)
                    {
                        username = id;
                    }
                }
                await _userService.SetStatusAsync(username, status);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Host")]
        [HttpPut]
        [Route("set/role")]
        public async Task<IActionResult> SetRoleAsync(string? username, string? email, string? id, string role)
        {
            try
            {
                if (username == null && email == null && id == null)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    username = identity.FindFirst(ClaimTypes.Name).Value;
                }
                else
                {
                    if (email != null)
                    {
                        username = email;
                    }
                    if (id != null)
                    {
                        username = id;
                    }
                }
                await _userService.SetRoleAsync(username, role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Host")]
        [HttpPut]
        [Route("remove/role")]
        public async Task<IActionResult> RemoveRoleAsync(string? username, string? email, string? id, string role)
        {
            try
            {
                if (username == null && email == null && id == null)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    username = identity.FindFirst(ClaimTypes.Name).Value;
                }
                else
                {
                    if (email != null)
                    {
                        username = email;
                    }
                    if (id != null)
                    {
                        username = id;
                    }
                }
                await _userService.SetRoleAsync(username, role);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}

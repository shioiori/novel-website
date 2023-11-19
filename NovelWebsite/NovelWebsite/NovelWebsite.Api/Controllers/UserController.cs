using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Services;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;
using System.Security.Claims;
using System.Xml.Linq;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;
        public UserController(UserService userService) 
        { 
            _userService = userService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet]
        [Route("get-all")]
        public async Task<PagedList<UserModel>> GetAllAsync([FromQuery] PagedListRequest request)
        {
            var users = await _userService.GetUsersAsync();
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("get-user")]
        public async Task<UserModel> GetAsync()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            string username = identity.FindFirst(ClaimTypes.Name).Value;
            return await _userService.GetUserByUsernameAsync(username);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet]
        [Route("get-by-role")]
        public async Task<PagedList<UserModel>> GetByRoleAsync(string role, [FromQuery] PagedListRequest request)
        {
            var users = await _userService.GetUsersByRoleAsync(role);
            return PagedList<UserModel>.ToPagedList(users, request);
        }


        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet]
        [Route("get-by-status")]
        public async Task<PagedList<UserModel>> GetByStatusAsync(string status, [FromQuery] PagedListRequest request)
        {
            int stt;
            if (int.TryParse(status, out var num))
            {
                stt = num;
            }
            else
            {
                stt = (int)((AccountStatus)Enum.Parse(typeof(AccountStatus), status, true));
            }
            var users = await _userService.GetUsersByStatusAsync(stt);
            return PagedList<UserModel>.ToPagedList(users, request);
        }


        [HttpGet]
        [Route("get-by-id")]
        public async Task<UserModel> GetById(string userId) {
            return await _userService.GetUserByIdAsync(userId);
        }

        [HttpGet]
        [Route("get-by-username")]
        public async Task<UserModel> GetByUsername(string username)
        {
            return await _userService.GetUserByUsernameAsync(username);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin,Host")]
        [HttpGet]
        [Route("search")]
        public async Task<PagedList<UserModel>> SearchUser(string name, [FromQuery] PagedListRequest request) 
        { 
            var users = await _userService.SearchUserAsync(name);
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [HttpGet]
        [Route("get-by-email")]
        public async Task<UserModel> GetByEmail(string email)
        {
            return await _userService.GetUserByEmailAsync(email);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> AddAsync(UserModel model) {
            try
            {
                await _userService.CreateUserAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateAsync(UserModel model) {
            try
            {
                if (model.Username == null)
                {
                    var identity = HttpContext.User.Identity as ClaimsIdentity;
                    string username = identity.FindFirst(ClaimTypes.Name).Value;
                    model.Username = username;
                }
                await _userService.UpdateUserAsync(model);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public async Task DeleteAsync(string userId) {
            await _userService.DeleteAsync(userId);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("set-status")] 
        public async Task SetStatusAsync(string userId, int status)
        {
            await _userService.SetUserStatusAsync(userId, status);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Host")]
        [HttpPut]
        [Route("set-role")]
        public async Task SetRoleAsync(string username, string role)
        {
            if (username == null)
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }
            await _userService.SetRoleAsync(username, role);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Host")]
        [HttpPut]
        [Route("remove-role")]
        public async Task RemoveRoleAsync(string username, string role)
        {
            if (username == null)
            {
                var identity = HttpContext.User.Identity as ClaimsIdentity;
                username = identity.FindFirst(ClaimTypes.Name).Value;
            }
            await _userService.RemoveRoleAsync(username, role);
        }

    }
}

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

        [HttpGet]
        [Route("get-all")]
        public async Task<PagedList<UserModel>> GetAllAsync([FromQuery] PagedListRequest request)
        {
            var users = await _userService.GetUsers();
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [HttpGet]
        [Route("get-by-role")]
        public async Task<PagedList<UserModel>> GetByRoleAsync(string name, [FromQuery] PagedListRequest request)
        {
            var users = await _userService.GetUsersByRole(name);
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

    }
}

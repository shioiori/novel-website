using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models.Response;

namespace NovelWebsite.NovelWebsite.Api.Controllers
{
    [Route("/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
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
        public async Task<PagedList<UserModel>> GetByRoleAsync(string roleId, [FromQuery] PagedListRequest request)
        {
            var users = await _userService.GetUsersByRole(roleId);
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [HttpGet]
        [Route("get-by-id")]
        public async Task<UserModel> GetOne(string userId) {
            return await _userService.GetUserByIdAsync(userId);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("add")]
        public void Add(UserModel model) {
            _userService.CreateUser(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [Route("update")]
        public void Update(UserModel model) {
            _userService.UpdateUser(model);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpDelete]
        [Route("delete")]
        public void Delete(string userId) {
            _userService.DeleteAsync(userId);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPut]
        [Route("set-status")] 
        public void SetStatus(string userId, int status)
        {
            _userService.SetUserStatusAsync(userId, status);
        }

    }
}

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
        public PagedList<UserModel> GetAll([FromQuery] PagedListRequest request)
        {
            var users = _userService.GetUsers();
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [HttpGet]
        [Route("get-by-role")]
        public PagedList<UserModel> GetByRole(int roleId, [FromQuery] PagedListRequest request)
        {
            var users = _userService.GetUsersByRole(roleId);
            return PagedList<UserModel>.ToPagedList(users, request);
        }

        [HttpGet]
        [Route("get-by-id")]
        public UserModel GetOne(int userId) {
            return _userService.GetUserById(userId);
        }

        [HttpPost]
        [Route("add")]
        public void Add(UserModel model) {
            _userService.CreateUser(model);
        }

        [HttpPost]
        [Route("update")]
        public void Update(UserModel model) {
            _userService.UpdateUser(model);
        }

        [HttpDelete]
        [Route("delete")]
        public void Delete(int id) {
            _userService.DeleteUser(id);
        }


        [HttpPut]
        [Route("set-status")] 
        public void SetStatus(int userId, int status)
        {
            _userService.SetUserStatus(userId, status);
        }


        [HttpPut]
        [Route("set-role")]
        public void SetRole(int userId, int roleId) {
            _userService.SetUserRole(userId, roleId);
        }

        [HttpPut]
        [Route("remove-role")]
        public void RemoveRole(int userId, int roleId) 
        { 
            _userService.RemoveUserRole(userId, roleId);
        }

    }
}

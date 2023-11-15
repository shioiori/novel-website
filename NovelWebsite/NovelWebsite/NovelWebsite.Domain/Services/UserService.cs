using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace NovelWebsite.Domain.Services
{

    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager,
                        IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserModel> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return _mapper.Map<User, UserModel>(user);
        }

        public async Task<UserModel> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<User, UserModel>(user);
        }

        public async Task<IEnumerable<UserModel>> GetUsersByRole(string roleId)
        {
            var users = await _userManager.GetUsersInRoleAsync(roleId);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        public async Task<IEnumerable<UserModel>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserModel>>(users);
        }

        public void CreateUser(UserModel model)
        {
            _userManager.CreateAsync(_mapper.Map<UserModel, User>(model));
        }

        public void UpdateUser(UserModel model)
        {
            _userManager.UpdateAsync(_mapper.Map<UserModel, User>(model));
        }

        public void DeleteUser(UserModel model)
        {
            _userManager.DeleteAsync(_mapper.Map<UserModel, User>(model));
        }

        public async Task DeleteAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            _userManager.DeleteAsync(user);
        }

        public async Task SetUserStatusAsync(string userId, int status)
        {
            var user = await _userManager.FindByIdAsync(userId);
            user.Status = status;
            _userManager.UpdateAsync(user);
        }

    }
}

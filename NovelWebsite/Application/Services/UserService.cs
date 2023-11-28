using AutoMapper;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.Application.Interfaces.Repositories;
using NovelWebsite.Application.Interfaces.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Constants;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using Application.Models.Dtos;

namespace NovelWebsite.Domain.Services
{

    public class UserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByStatusAsync(int status)
        {
            var users = await _userManager.Users.Where(x => x.Status == status).ToListAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task<IEnumerable<UserDto>> SearchUserAsync(string name)
        {
            var users = await _userManager.Users.Where(x => string.IsNullOrEmpty(name) || x.UserName.ToLower().Trim().Contains(name.ToLower().Trim())
                                                        || x.Email.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task CreateUserAsync(UserDto model)
        {
            var user = _mapper.Map<UserDto, User>(model);
            var res = await _userManager.CreateAsync(user, model.Password);
        }

        public async Task UpdateUserAsync(UserDto model)
        {
            User user;
            if (model.Username != null)
            {
                user = await _userManager.FindByNameAsync(model.Username);
            }
            else if (model.Email != null){
                user = await _userManager.FindByEmailAsync(model.Email);
            }
            else
            {
                return;
            }
            user.Name = model.Name;
            user.Avatar = model.Avatar;
            user.CoverPhoto = model.CoverPhoto;
            var res = await _userManager.UpdateAsync(user);
        }

        public void DeleteUser(UserDto model)
        {
            _userManager.DeleteAsync(_mapper.Map<UserDto, User>(model));
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

        public async Task<UserDto> GetUserByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return _mapper.Map<User, UserDto>(user);
        }

        public async Task SetRoleAsync(string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (!await _roleManager.RoleExistsAsync(role))
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = role,
                });
            }
            await _userManager.AddToRoleAsync(user, role);
        }

        public async Task RemoveRoleAsync(string username, string role)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
        }
    }
}

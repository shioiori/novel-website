using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;

namespace NovelWebsite.Domain.Services
{

    public class UserService : GenericService<User, UserDto>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager) : base()
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserDto> GetCurrentUserAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return await MapDtosAsync(user);
        }

        public async Task<UserDto> GetUserByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await MapDtosAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByRoleAsync(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return await MapDtosAsync(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersByStatusAsync(int status)
        {
            var users = await _userManager.Users.Where(x => x.Status == status).ToListAsync();
            return await MapDtosAsync(users);
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return await MapDtosAsync(users);
        }

        public async Task<IEnumerable<UserDto>> SearchUserAsync(string name)
        {
            var users = await _userManager.Users.Where(x => string.IsNullOrEmpty(name) || x.UserName.ToLower().Trim().Contains(name.ToLower().Trim())
                                                        || x.Email.ToLower().Trim().Contains(name.ToLower().Trim())).ToListAsync();
            return await MapDtosAsync(users);
        }

        public override async Task<UserDto> AddAsync(UserDto model)
        {
            var user = await MapEntityAsync(model);
            var res = await _userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                var dto = await _userManager.FindByEmailAsync(user.Email);
                return await MapDtosAsync(dto);
            }
            throw (new Exception("Add user failed"));
        }

        public override async Task<UserDto> UpdateAsync(UserDto model)
        {
            User user;
            if (model.Username != null)
            {
                user = await _userManager.FindByNameAsync(model.Username);
            }
            else if (model.Email != null){
                user = await _userManager.FindByEmailAsync(model.Email);
            }
            else if (model.UserId != null)
            {
                user = await _userManager.FindByIdAsync(model.UserId);
            }
            else
            {
                throw new Exception("Update user info invalid");
            }
            user.Name = model.Name;
            user.Avatar = model.Avatar;
            user.CoverPhoto = model.CoverPhoto;
            var res = await _userManager.UpdateAsync(user);
            if (res.Succeeded)
            {
                return await MapDtosAsync(user);
            }
            else
            {
                throw new Exception("Update failed");
            }
        }

        public override async Task DeleteAsync(object id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
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
            return await MapDtosAsync(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await MapDtosAsync(user);
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

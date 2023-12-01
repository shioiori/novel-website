using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NovelWebsite.Application.Models.Dtos;
using Application.Services.Base;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Domain.Interfaces;
using AutoMapper;
using NovelWebsite.Domain.Enums;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Interfaces;
using NovelWebsite.Application.Utils;

namespace NovelWebsite.Domain.Services
{

    public class UserService : GenericService<User, UserDto>, IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public UserService(UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IUserRepository userRepository,
            IMapper mapper) : base(userRepository, mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<UserDto> GetCurrentAsync(ClaimsPrincipal principal)
        {
            var user = await _userManager.GetUserAsync(principal);
            return await MapDtoAsync(user);
        }

        public async Task<UserDto> GetByIdAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            return await MapDtoAsync(user);
        }

        public async Task<UserDto> GetByUsernameAsync(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return await MapDtoAsync(user);
        }

        public async Task<UserDto> GetByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return await MapDtoAsync(user);
        }

        public async Task<IEnumerable<UserDto>> GetByRoleAsync(string role, PagedListRequest request)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return await MapDtosAsync(PagedList<User>.AsEnumerable(users));
        }

        public async Task<IEnumerable<UserDto>> GetByStatusAsync(int status, PagedListRequest request)
        {
            var users = _userManager.Users.Where(x => x.Status == status);
            return await MapDtosAsync(PagedList<User>.AsEnumerable(users, request));
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return await MapDtosAsync(users);
        }

        public override async Task<UserDto> AddAsync(UserDto model)
        {
            var user = await MapEntityAsync(model);
            var res = await _userManager.CreateAsync(user, model.Password);
            if (res.Succeeded)
            {
                var dto = await _userManager.FindByEmailAsync(user.Email);
                return await MapDtoAsync(dto);
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
            else if (model.Email != null)
            {
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
                return await MapDtoAsync(user);
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

        public async Task SetStatusAsync(string userId, int status)
        {
            var user = await FindAsync(userId);
            user.Status = status;
            _userManager.UpdateAsync(user);
        }

        public async Task SetRoleAsync(string username, string role)
        {
            var user = await FindAsync(username);
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
            var user = await FindAsync(username);
            if (await _roleManager.RoleExistsAsync(role))
            {
                await _userManager.RemoveFromRoleAsync(user, role);
            }
        }

        private async Task<User> FindAsync(string id)
        {
            User user = await _userManager.FindByNameAsync(id);
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(id);
            }
            if (user == null)
            {
                user = await _userManager.FindByIdAsync(id);
            }
            if (user == null)
            {
                throw new Exception("User not found");
            }
            return user;
        }
    }
}

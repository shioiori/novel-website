using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Utils;
using NovelWebsite.Domain.Entities;
using NovelWebsite.Application.Models.Response;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using NovelWebsite.Domain.Constants;
using System.Text;
using Microsoft.Extensions.Configuration;
using Application.Models.Dtos;
using Application.Interfaces;

namespace NovelWebsite.Application.Services
{
    public class AccessService : IAccessService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccessService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AuthenticationResponse> LoginAsync(LoginRequest model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                if (user.EmailConfirmed == false)
                {
                    return new AuthenticationResponse()
                    {
                        Success = false,
                        Message = "Email is not confirmed",
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
                else if (await _userManager.CheckPasswordAsync(user, model.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                    claims.Add(new Claim(ClaimTypes.Name, user.UserName));
                    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
                    foreach (var userRole in userRoles)
                    {
                        claims.Add(new Claim(ClaimTypes.Role, userRole));
                    }

                    var token = GetToken(claims);

                    return new AuthenticationResponse()
                    {
                        Success = true,
                        Message = "Login success",
                        AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
                        StatusCode = StatusCodes.Status200OK,
                    };
                }
                else
                {
                    return new AuthenticationResponse()
                    {
                        Success = false,
                        Message = "Username or password is not match",
                        StatusCode = StatusCodes.Status401Unauthorized
                    };
                }
            }
            return new AuthenticationResponse()
            {
                Success = false,
                Message = "Username or password is not match",
                StatusCode = StatusCodes.Status401Unauthorized
            };
        }

        public async Task<AuthenticationResponse> RegisterAsync(RegisterRequest model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "This account is registed",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            var user = _mapper.Map<RegisterRequest, User>(model);
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            {
                await _roleManager.CreateAsync(new Role()
                {
                    Name = UserRoles.User,
                });
            }
            await _userManager.AddToRoleAsync(user, UserRoles.User);

            if (!result.Succeeded)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Create user fail",
                    StatusCode = StatusCodes.Status500InternalServerError
                };
            }
            return new AuthenticationResponse()
            {
                Success = true,
                Message = "Register success",
                StatusCode = StatusCodes.Status204NoContent,
                User = _mapper.Map<UserDto>(user)
            };
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:Issuer"],
                audience: _configuration["JWT:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );
            return token;
        }

    }
}

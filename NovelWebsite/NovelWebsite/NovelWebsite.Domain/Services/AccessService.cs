using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Constants;
using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Interfaces.Services;
using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.MailKit;
using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Domain.Utils;
using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using Org.BouncyCastle.Asn1.Ocsp;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Environment = NovelWebsite.NovelWebsite.Core.Constants.Environment;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AccessService : IAccessService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IMapper _mapper;
        private readonly IMailService _mailService;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IConfiguration _configuration;

        public AccessService(
            UserManager<User> userManager,
            RoleManager<Role> roleManager,
            IMailService mailService,
            IMapper mapper,
            IHttpContextAccessor contextAccessor,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
            _mapper = mapper;
            _contextAccessor = contextAccessor;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
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

        [HttpPost]
        [Route("register")]
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
            await GenerateEmailConfimationAsync(user);
            return new AuthenticationResponse()
            {
                Success = true,
                Message = "Register success. Please check your email to confirm account.",
                StatusCode = StatusCodes.Status204NoContent,
            };
        }

        private async Task GenerateEmailConfimationAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = _contextAccessor.HttpContext.Request.Scheme
                + "://"
                + _contextAccessor.HttpContext.Request.Host;
            var confirmUrl = url + "/email-verify"
                + "?email=" + user.Email
                + "&token=" + WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(token));
            var content = new MailContent()
            {
                To = user.Email,
                Subject = "Xác minh tài khoản Novel Website",
                Body = EmailTemplate.GenerateEmailTemplate(user.UserName, confirmUrl)
            };
            await _mailService.SendMail(content);
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

        public async Task<AuthenticationResponse> ConfirmEmailAsync(string email, string token)
        {
            try
            {
                var decode = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(token));
                User user = await _userManager.FindByEmailAsync(email);
                if (await _userManager.IsEmailConfirmedAsync(user))
                {
                    return new AuthenticationResponse()
                    {
                        Success = false,
                        Message = "Your email was confirmed",
                        StatusCode = StatusCodes.Status400BadRequest,
                    };
                }

                var result = await _userManager.ConfirmEmailAsync(user, decode);
                if (result.Succeeded)
                {
                    user.Status = (int)AccountStatus.Active;
                    _userManager.UpdateAsync(user);
                    return new AuthenticationResponse()
                    {
                        Success = true,
                        Message = "Email confimation success. Now you can login normally",
                        StatusCode = StatusCodes.Status202Accepted,
                    };
                }
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Oops, there is something wrong",
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
            catch (Exception ex)
            {
                return new AuthenticationResponse()
                {
                    Success = false,
                    Message = "Oops, there is something wrong",
                    StatusCode = StatusCodes.Status500InternalServerError,
                };
            }
        }
    }
}

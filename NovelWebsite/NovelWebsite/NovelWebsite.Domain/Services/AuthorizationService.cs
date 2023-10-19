using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationService(IUserRepository userRepository,
                                    IUserRoleRepository userRoleRepository,
                                    IHttpContextAccessor httpContextAccessor){
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SetClaims(UserModel user, string authenticationType){
            var claims = CreateClaims(user);
            await SaveClaims(claims, authenticationType);
        }

        public IEnumerable<Claim> CreateClaims(UserModel user){
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Username));
            var roles = _userRoleRepository.Filter(x => x.UserId == user.UserId);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Role.RoleName));
            }
            claims.Add(new Claim(ClaimTypes.Email, user.Email));
            return claims;
        }
        
        public async Task SaveClaims(IEnumerable<Claim> claims, string authenticationType){
            var claimIndentity = new ClaimsIdentity(claims, authenticationType);
            _httpContextAccessor.HttpContext.Session.SetString("AuthenticationType", authenticationType.ToString());
            await _httpContextAccessor.HttpContext.SignInAsync(authenticationType, new ClaimsPrincipal(claimIndentity));
        }

        public async Task RemoveClaims()
        {
            var authenticationType = _httpContextAccessor.HttpContext.Session.GetString("AuthenticationType");
            await _httpContextAccessor.HttpContext.SignOutAsync(authenticationType);
            _httpContextAccessor.HttpContext.Session.Remove("AuthenticationType");
        }
    }
}
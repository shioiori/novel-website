using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using NovelWebsite.NovelWebsite.Core.Interfaces.Repositories;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthorizationService(IAccountRepository accountRepository, IUserRepository userRepository,
                                    IHttpContextAccessor httpContextAccessor){
            _accountRepository = accountRepository;
            _userRepository = userRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task SetClaims(AccountModel account, string authenticationType){
            var claims = CreateClaims(account);
            await SaveClaims(claims, authenticationType);
        }

        public IEnumerable<Claim> CreateClaims(AccountModel account){
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, account.Username));
            claims.Add(new Claim(ClaimTypes.Role, account.Role.ToString()));
            claims.Add(new Claim(ClaimTypes.Sid, account.UserId.ToString()));
            claims.Add(new Claim(ClaimTypes.Email, account.Email));
            return claims;
        }
        
        public async Task SaveClaims(IEnumerable<Claim> claims, string authenticationType){
            var claimIndentity = new ClaimsIdentity(claims, authenticationType);
            await _httpContextAccessor.HttpContext.SignInAsync(authenticationType, new ClaimsPrincipal(claimIndentity));
        }
    }
}
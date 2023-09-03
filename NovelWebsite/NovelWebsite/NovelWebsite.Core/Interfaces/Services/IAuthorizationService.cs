using System.Security.Claims;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public interface IAuthorizationService
    {
        IEnumerable<Claim> CreateClaims(AccountModel account);
        Task SaveClaims(IEnumerable<Claim> claims, string authenticationType);
        Task SetClaims(AccountModel account, string authenticationType);
    }

}
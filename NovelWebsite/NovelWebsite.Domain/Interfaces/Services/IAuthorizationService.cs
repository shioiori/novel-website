using System.Security.Claims;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public interface IAuthorizationService
    {
        Task SetClaims(AccountModel account, string authenticationType);
        Task RemoveClaims();
    }

}
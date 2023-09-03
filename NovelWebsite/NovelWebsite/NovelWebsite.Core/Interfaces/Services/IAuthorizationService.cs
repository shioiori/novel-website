using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Domain.Services
{
    public interface IAuthorizationService
    {
        AuthorizationResponse Login(LoginRequest loginRequest);

    }
}
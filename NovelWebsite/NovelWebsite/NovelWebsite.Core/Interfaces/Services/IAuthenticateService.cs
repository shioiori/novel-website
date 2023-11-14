using NovelWebsite.NovelWebsite.Core.Models;
using NovelWebsite.NovelWebsite.Core.Models.Request;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(LoginRequest loginRequest);
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
    }
}

using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(LoginRequest loginRequest);
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest request);
    }
}

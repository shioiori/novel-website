using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces
{
    public interface IAuthenticationService
    {
        AuthenticationResponse Login(LoginRequest loginRequest);
        AuthenticationResponse Register(RegisterRequest request);
    }
}

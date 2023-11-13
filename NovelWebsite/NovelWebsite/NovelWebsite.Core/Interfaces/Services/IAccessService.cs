using NovelWebsite.NovelWebsite.Core.Models.Request;
using NovelWebsite.NovelWebsite.Core.Models;

namespace NovelWebsite.NovelWebsite.Core.Interfaces.Services
{
    public interface IAccessService
    {
        Task<AuthenticationResponse> LoginAsync(LoginRequest model);
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest model);
        Task<AuthenticationResponse> ConfirmEmailAsync(string email, string token);
    }

}

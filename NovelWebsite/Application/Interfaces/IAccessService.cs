using NovelWebsite.Application.Models.Request;
using NovelWebsite.Application.Models.Response;

namespace Application.Interfaces
{
    public interface IAccessService
    {
        Task<AuthenticationResponse> LoginAsync(LoginRequest model);
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest model);
    }
}
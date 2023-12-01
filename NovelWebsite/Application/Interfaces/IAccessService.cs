using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Application.Models.Responses;

namespace NovelWebsite.Application.Interfaces
{
    public interface IAccessService
    {
        Task<AuthenticationResponse> LoginAsync(LoginRequest model);
        Task<AuthenticationResponse> RegisterAsync(RegisterRequest model);
    }
}
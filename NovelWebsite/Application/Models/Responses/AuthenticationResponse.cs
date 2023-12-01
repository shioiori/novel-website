using NovelWebsite.Application.Models.Dtos;

namespace NovelWebsite.Application.Models.Responses
{
    public class AuthenticationResponse : Response
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public UserDto User { get; set; }
    }
}
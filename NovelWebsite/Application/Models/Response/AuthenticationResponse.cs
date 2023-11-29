namespace NovelWebsite.Application.Models.Response
{
    public class AuthenticationResponse : Response
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
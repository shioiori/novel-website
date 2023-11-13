namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string AccessToken { get; set; }
        public string? RefreshToken { get; set; }
        public int StatusCode { get; set; }
    }
}
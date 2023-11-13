namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int StatusCode { get; set; }
    }
}
namespace NovelWebsite.Application.Models.Requests
{
    public class RegisterRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
    }
}

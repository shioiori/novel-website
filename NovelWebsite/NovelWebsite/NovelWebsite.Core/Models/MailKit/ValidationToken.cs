namespace NovelWebsite.NovelWebsite.Core.Models.MailKit
{
    public class ValidationToken
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime ExpiredDate { get; set; }
    }
}

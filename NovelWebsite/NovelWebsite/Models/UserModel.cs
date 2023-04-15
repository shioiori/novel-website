using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class UserModel : BaseModel
    {
        public string? AccountName { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string? Avatar { get; set; }
        public string? CoverPhoto { get; set; }
        public string Email { get; set; }
        public string? Role { get; set; }
    }
}

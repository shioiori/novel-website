using System.ComponentModel.DataAnnotations;
using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class AccountModel : BaseModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public AccountRole Role { get; set; }
    }
}

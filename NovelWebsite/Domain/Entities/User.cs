using NovelWebsite.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace NovelWebsite.Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string CoverPhoto { get; set; } = "default.jpg";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        //public string? ValidateEmailToken { get; set; }
        public int Status { get; set; } = (int)AccountStatus.Verifying;
        //public string? RefreshToken { get; set; }
        //public DateTime RefreshTokenExpiryTime { get; set; }
    }
}

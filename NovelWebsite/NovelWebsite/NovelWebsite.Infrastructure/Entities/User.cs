using Microsoft.AspNetCore.Identity;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string CoverPhoto { get; set; } = "default.jpg";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)AccountStatus.Verifying;
    }
}

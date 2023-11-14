using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string CoverPhoto { get; set; } = "default.jpg";
        public DateTime CreatedDate { get; set; } 
        public int Status { get; set; }
        public IEnumerable<RoleModel> Role { get; set; }
    }
}

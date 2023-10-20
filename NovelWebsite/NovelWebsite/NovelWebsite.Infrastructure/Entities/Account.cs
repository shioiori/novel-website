using Microsoft.AspNetCore.Authentication.Cookies;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        [ForeignKey("fk_account_role")]
        public int RoleId { get; set; } = (int)AccountRole.User;
        public virtual Role Role { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string LoginProvide { get; set; } = CookieAuthenticationDefaults.AuthenticationScheme;
        public int Status { get; set; } = (int)AccountStatus.Verifying;
    }
}

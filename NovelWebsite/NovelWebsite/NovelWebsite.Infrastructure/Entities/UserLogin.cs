using Microsoft.AspNetCore.Authentication.Cookies;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class UserLogin
    {
        [ForeignKey("fk_ul_user")]
        public int UserId { get; set; }
        [Key]
        public string LoginProvider { get; set; } = CookieAuthenticationDefaults.AuthenticationScheme;
        [Key]
        public string ProviderKey {  get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)AccountStatus.Verifying;
    }
}

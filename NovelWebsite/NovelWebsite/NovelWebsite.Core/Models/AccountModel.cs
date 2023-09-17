using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication.Cookies;
using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class AccountModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
        public AccountRole Role { get; set; }
        public UserModel User { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LoginProvide { get; set; } 
        public int Status { get; set; }
    }
}

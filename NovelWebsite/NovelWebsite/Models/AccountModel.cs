using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AccountModel : BaseModel
    {
        [Required]
        public string AccountName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
    }
}

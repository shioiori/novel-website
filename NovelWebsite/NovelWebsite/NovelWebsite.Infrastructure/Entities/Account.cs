using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Account : BaseEntity
    {
        [Key]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        [ForeignKey("fk_account_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_account_role")]
        public int RoleId { get; set; }
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
    }
}

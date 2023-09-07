using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string CoverPhoto { get; set; } = "default.jpg";
        [ForeignKey("fk_user_account")]
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}

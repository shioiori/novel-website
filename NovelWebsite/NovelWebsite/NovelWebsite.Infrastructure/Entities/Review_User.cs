using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Review_User
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_review")]
        public int ReviewId { get; set; }
        public int InteractType { get; set; }
        public User User { get; set; }
        public virtual Review Review { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Post_User
    {
        [ForeignKey("fk_post_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_user_post")]
        public int PostId { get; set; }
        [ForeignKey("fk_pu_interaction")]
        public int InteractType { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}

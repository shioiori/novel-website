using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class PostUsers
    {
        [ForeignKey("fk_post_user")]
        public string UserId { get; set; }
        [ForeignKey("fk_user_post")]
        public string PostId { get; set; }
        [ForeignKey("fk_pu_interaction")]
        public int InteractionId { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
        //public virtual Interaction Interaction { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class CommentUserLikeEntity
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_comment")]
        public int CommentId { get; set; }
        public int InteractType { get; set; }
        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}

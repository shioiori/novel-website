using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    // thực thể này lưu chứa tương tác của các người dùng khác với comment như like comment, dislike
    public class CommentUsers
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_comment")]
        public int CommentId { get; set; }
        [ForeignKey("fk_cu_interaction")]
        public int InteractType { get; set; }
        [ForeignKey("fk_cu_reply_comment")]
        public int? ReplyCommentId { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Comment ReplyComment { get; set; }
    }
}

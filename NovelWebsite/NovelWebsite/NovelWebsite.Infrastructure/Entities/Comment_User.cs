using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    // thực thể này lưu chứa tương tác của các người dùng khác với comment như like, dislike, reply
    public class Comment_User
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_comment")]
        public int CommentId { get; set; }
        public int InteractType { get; set; }
        public int ReplyCommentId {get; set; }
        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Comment ReplyComment { get; set; }
    }
}

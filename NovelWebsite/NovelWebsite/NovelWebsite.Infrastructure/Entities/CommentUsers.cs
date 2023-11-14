using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    // thực thể này lưu chứa tương tác của các người dùng khác với comment như like comment, dislike
    public class CommentUsers
    {
        [ForeignKey("fk_user")]
        public string UserId { get; set; }
        [ForeignKey("fk_comment")]
        public string CommentId { get; set; }
        [ForeignKey("fk_cmtu_interaction")]
        public int InteractionId { get; set; }
        [ForeignKey("fk_reply_comment")]
        public string? ReplyCommentId { get; set; }
        public virtual User User {  get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Comment ReplyComment { get; set; }
        //public virtual Interaction Interaction { get; set; }

    }
}

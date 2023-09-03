using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BookId")]
        public int? BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("ChapterId")]
        public int? ChapterId { get; set; }
        public Chapter Chapter { get; set; }
        [ForeignKey("PostId")]
        public int? PostId { get; set; }
        public Post Post { get; set; }

        [ForeignKey("CommentId")]
        public int? ReplyCommentId { get; set; }
        public Comment ReplyComment { get; set; }
        public int NumberOfReplyComment { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string? UpdatedBy { get; set; }
    }
}

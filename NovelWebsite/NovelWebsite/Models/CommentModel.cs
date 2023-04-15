using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int BookId { get; set; }
        public int ChapterId { get; set; }
        public int PostId { get; set; }
        public int ReplyCommentId { get; set; }
        [Required]
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}

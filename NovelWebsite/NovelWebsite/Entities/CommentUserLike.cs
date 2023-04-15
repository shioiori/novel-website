using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class CommentUserLikeEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("CommentId")]
        public int CommentId { get; set; } 
        public CommentEntity Comment { get; set; }
    }
}

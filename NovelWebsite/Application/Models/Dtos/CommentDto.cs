using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Application.Models.Dtos
{
    public class CommentDto
    {
        public string CommentId { get; set; }
        public string UserId { get; set; }
        public UserDto? User { get; set; }
        public string BookId { get; set; }
        public string ChapterId { get; set; }
        public string PostId { get; set; }
        public string ReviewId { get; set; }
        public string ReplyCommentId { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
    }
}

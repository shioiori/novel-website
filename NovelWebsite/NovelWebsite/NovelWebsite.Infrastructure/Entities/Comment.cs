using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        [ForeignKey("fk_user_comment")]
        public int? UserId { get; set; }
        [ForeignKey("fk_book_comment")]
        public int? BookId { get; set; }
        [ForeignKey("fk_chapter_comment")]
        public int? ChapterId { get; set; }
        [ForeignKey("fk_post_comment")]
        public int? PostId { get; set; }
        [ForeignKey("fk_review_comment")]
        public int? ReviewId { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        
        public virtual User User { get; set; }
        public virtual Book Book { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual Post Post { get; set; }
        public virtual Review Review { get; set; }
    }
}

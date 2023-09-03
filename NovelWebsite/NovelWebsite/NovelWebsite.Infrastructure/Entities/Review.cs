using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Review : BaseEntity
    {
        [Key]
        public int ReviewId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
    }
}

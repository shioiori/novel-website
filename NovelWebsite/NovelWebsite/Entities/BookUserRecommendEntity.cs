using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class BookUserRecommendEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("BookId")]
        public int BookId { get; set; } 
        public BookEntity Book { get; set; }
    }
}

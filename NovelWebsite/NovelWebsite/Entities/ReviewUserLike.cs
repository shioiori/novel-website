using NovelWebsite.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class ReviewUserLikeEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("ReviewId")]
        public int ReviewId { get; set; } 
        public ReviewEntity Review { get; set; }
    }
}

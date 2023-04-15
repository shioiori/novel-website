using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class ChapterUserLikeEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("ChapterId")]
        public int ChapterId { get; set; } 
        public ChapterEntity Chapter { get; set; }
    }
}

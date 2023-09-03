using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class ChapterUser
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_chapter")]
        public int ChapterId { get; set; }
        public int InteractType { get; set; }
        public User User { get; set; }
        public Chapter Chapter { get; set; }
    }
}

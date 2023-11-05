using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Chapter_User
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_chapter")]
        public int ChapterId { get; set; }
        [ForeignKey("fk_cu_interaction")]
        public int InteractType { get; set; }
        public virtual User User { get; set; }
        public virtual Chapter Chapter { get; set; }
    }
}

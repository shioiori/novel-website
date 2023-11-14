using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class ChapterUsers
    {
        [ForeignKey("fk_user")]
        public string UserId { get; set; }
        [ForeignKey("fk_chapter")]
        public string ChapterId { get; set; }
        [ForeignKey("fk_cu_interaction")]
        public int InteractionId { get; set; }
        public virtual Chapter Chapter { get; set; }
        public virtual User User { get; set; }
        //public virtual Interaction Interaction { get; set; }
    }
}

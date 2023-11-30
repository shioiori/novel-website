using NovelWebsite.Domain.Enums;
using NovelWebsite.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Domain.Entities
{
    public class BookUsers
    {
        [ForeignKey("fk_user_book")]
        public string UserId { get; set; }
        [ForeignKey("fk_book_user")]
        public string BookId { get; set; }
        [ForeignKey("fk_bu_interaction")]
        public int InteractionId { get; set; }
        [ForeignKey("fk_bu_chapterid")]
        public string? ChapterId { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        //public virtual Interaction Interaction { get; set; }

    }
}

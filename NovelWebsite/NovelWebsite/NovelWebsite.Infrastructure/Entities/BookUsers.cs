using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class BookUsers
    {
        [ForeignKey("fk_user_book")]
        public string UserId { get; set; }
        [ForeignKey("fk_book_user")]
        public string BookId { get; set; }
        [ForeignKey("fk_bu_interaction")]
        public int InteractionId { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
        //public virtual Interaction Interaction { get; set; }

    }
}

using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class BookUsers
    {
        [ForeignKey("fk_user_book")]
        public int UserId { get; set; }
        [ForeignKey("fk_book_user")]
        public int BookId { get; set; }
        [ForeignKey("fk_bu_interaction")]
        public int InteractType { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

    }
}

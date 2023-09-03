using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Book_User
    {
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_book")]
        public int BookId { get; set; }
        public int InteractType { get; set; }
        public virtual Book Book { get; set; }
        public virtual User User { get; set; }

    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Book_Tag
    {
        [ForeignKey("fk_book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("fk_tag")]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

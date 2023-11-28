using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Domain.Entities
{
    public class BookTags
    {
        [ForeignKey("fk_book")]
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        [ForeignKey("fk_tag")]
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}

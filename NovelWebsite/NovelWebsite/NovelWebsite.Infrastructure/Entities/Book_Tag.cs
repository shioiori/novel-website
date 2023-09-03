using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Book_Tag
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        [ForeignKey("TagId")]
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}

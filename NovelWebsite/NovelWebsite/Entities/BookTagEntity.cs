using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Entities
{
    public class BookTagEntity
    {
        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        [ForeignKey("TagId")]
        public int TagId { get; set; }
        public TagEntity Tag { get; set; }
    }
}

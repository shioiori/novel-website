using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Chapter : BaseEntity
    {
        [Key]
        public int ChapterId { get; set; }

        [ForeignKey("BookId")]
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int? ChapterNumber { get; set; }
        public string? ChapterName { get; set; }
        public string? Content { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public string? Slug { get; set; }
    }
}

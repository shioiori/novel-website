using NovelWebsite.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Domain.Entities
{
    public class Chapter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ChapterId { get; set; }

        [ForeignKey("fk_book")]
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public int ChapterIndex { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int Views { get; set; } = 0;
        public string Slug { get; set; } = String.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)UploadStatus.Publish;
    }
}

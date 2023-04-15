using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class ChapterModel : BaseModel
    {
        public int? ChapterId { get; set; }
        public int BookId { get; set; }
        public string? ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
    }
}

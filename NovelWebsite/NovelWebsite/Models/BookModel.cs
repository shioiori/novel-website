using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookModel : BaseModel
    {
        public int? BookId { get; set; }
        [Required]
        public string BookName { get; set; }
        public int? AuthorId { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public int? UserId { get; set; }
        public int? NumberOfChapters { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public int? Recommends { get; set; }
        [Required]
        public string Avatar { get; set; }
        [Required]
        public string Introduce { get; set; }
        [Required]
        public string BookStatusId { get; set; }
        public List<int>? Tag { get; set; }
    }
}

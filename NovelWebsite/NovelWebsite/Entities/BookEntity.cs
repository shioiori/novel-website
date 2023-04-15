using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class BookEntity : BaseEntity
    {
        [Key]
        public int BookId { get; set; }
        public string BookName { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public AuthorEntity Author { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        public int? NumberOfChapters { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public int? Recommends { get; set; }
        public string? Avatar { get; set; }
        public string? Introduce { get; set; }
        [ForeignKey("BookStatusId")]
        public string BookStatusId { get; set; }
        public BookStatusEntity BookStatus { get; set; }
        public string? Slug { get; set; }
    }
}

using NovelWebsite.NovelWebsite.Core.Enums;
using NovelWebsite.NovelWebsite.Core.Constants;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }
        public string BookName { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string Introduce { get; set; } = String.Empty;
        public string BookStatus { get; set; } = NovelWebsite.Core.Constants.BookStatus.Ongoing;
        public string Slug { get; set; }
        public int Views { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = (int)UploadStatus.Moderation;
        public bool IsDeleted { get; set; } = false;
    }
}

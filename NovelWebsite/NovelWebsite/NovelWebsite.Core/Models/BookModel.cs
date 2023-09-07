using NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class BookModel
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel? Author { get; set; }
        public int UserId {  get; set; }
        public UserModel? User { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string Introduce { get; set; } = String.Empty;
        public string BookStatus { get; set; } = NovelWebsite.Core.Constants.BookStatus.Ongoing;
        public string Slug { get; set; }
        public int Views { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = (int)UploadStatus.Moderation;
        public bool IsDeleted { get; set; } = false;
        public IEnumerable<ChapterModel>? Chapters { get; set; }
        public int TotalChapters { get; set; } = 0;
    }
}

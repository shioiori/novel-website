using NovelWebsite.NovelWebsite.Infrastructure.Entities;
using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NovelWebsite.NovelWebsite.Core.Constants;
using BookStatus = NovelWebsite.NovelWebsite.Core.Constants.BookStatus;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class BookModel
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public CategoryModel Category { get; set; }
        public int AuthorId { get; set; }
        public AuthorModel Author { get; set; }
        public string UserId {  get; set; }
        public UserModel User { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string Introduce { get; set; } = String.Empty;
        public string BookStatus { get; set; }
        public string Slug { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Recommends { get; set; } = 0;
        public int Follows { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)UploadStatus.Moderation;
        public bool IsDeleted { get; set; } = false;
        public int TotalChapters { get; set; } = 0;
        public IEnumerable<TagModel> Tags { get; set; } = null;
    }
}

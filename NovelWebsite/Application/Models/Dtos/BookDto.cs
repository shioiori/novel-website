using NovelWebsite.Domain.Enums;
using Application.Models.Objects;

namespace Application.Models.Dtos
{
    public class BookDto
    {
        public string BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public CategoryDto? Category { get; set; }
        public int AuthorId { get; set; }
        public AuthorDto? Author { get; set; }
        public string UserId { get; set; }
        public UserDto? User { get; set; }
        public string Avatar { get; set; } 
        public string Introduce { get; set; } 
        public string BookStatus { get; set; }
        public string Slug { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Recommends { get; set; } = 0;
        public int Follows { get; set; } = 0;
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int Status { get; set; } = (int)UploadStatus.Moderation;
        public Label? StatusLabel { get; set; }
        public int TotalChapters { get; set; } = 0;
        public IEnumerable<TagDto>? Tags { get; set; }

    }
}

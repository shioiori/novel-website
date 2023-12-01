using NovelWebsite.Application.Models.Objects;

namespace NovelWebsite.Application.Models.Dtos
{
    public class PostDto
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Slug { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public int Views { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; }
        public Label StatusLabel { get; set; }
    }
}

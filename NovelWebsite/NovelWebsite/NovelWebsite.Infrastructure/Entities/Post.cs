using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }
        [ForeignKey("fk_user")]
        public virtual User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Content { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public string? Slug { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)UploadStatus.Moderation;
    }
}

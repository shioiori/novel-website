using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class PostModel
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
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
        public string StatusName { get; set; }
        public string StatusLabelColor { get; set; }
    }
}

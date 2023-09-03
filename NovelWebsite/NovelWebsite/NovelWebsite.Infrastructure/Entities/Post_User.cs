using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Post_User
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

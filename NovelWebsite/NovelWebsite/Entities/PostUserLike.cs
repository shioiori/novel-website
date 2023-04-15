using NovelWebsite.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class PostUserLikeEntity
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [ForeignKey("PostId")]
        public int PostId { get; set; } 
        public PostEntity Post { get; set; }
    }
}

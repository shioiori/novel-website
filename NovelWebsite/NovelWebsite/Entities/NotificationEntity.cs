using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Entities
{
    public class NotificationEntity
    {
        [Key]
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int TypeId { get; set; }
        public int BookId { get; set; }
        public int CommentId { get; set; }
        public int ChapterId { get; set; }
        public int PostId { get; set; }
        public int ReviewId { get; set; }
        public virtual UserEntity FromUser { get; set; }
        public virtual UserEntity ToUser { get; set; }
        public virtual NotificationTypeEnitity Type { get; set; }
        public virtual BookEntity Book { get; set; }
        public virtual CommentEntity Comment { get; set; }
        public virtual ChapterEntity Chapter { get; set; }
        public virtual PostEntity Post { get; set; }
        public virtual ReviewEntity Review { get; set; }
    }
}

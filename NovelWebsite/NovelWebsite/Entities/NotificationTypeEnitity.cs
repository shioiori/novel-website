

using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Entities
{
    public class NotificationTypeEnitity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
    }

    public enum NotificationType
    {
        ReplyComment = 1,
        CommentBook = 2,
        FollowBook = 3,
        RecBook = 4,
        AddChapter = 5,
        AddReview = 6
    }
}

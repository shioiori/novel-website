namespace NovelWebsite.Models
{
    public class NotificationModel
    {
        public int Id { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int TypeId { get; set; }
    }
}

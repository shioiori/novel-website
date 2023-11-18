namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class PostModel
    {
        public string PostId { get; set; }
        public string UserId { get; set; }
        public UserModel? User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public string? Slug { get; set; }
        public DateTime CreatedDate {  get; set; } = DateTime.Now;
    }
}

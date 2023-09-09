namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class PostModel
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedDate {  get; set; }
    }
}

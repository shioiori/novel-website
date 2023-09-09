namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class ReviewModel : BaseModel
    {
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public int BookId { get; set; }
        public BookModel Book { get; set; }
        public string Content { get; set; }
        public int? Likes { get; set; }
        public int? Dislikes { get; set; }
        
    }
}
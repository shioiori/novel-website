namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class ReviewModel
    {
        public string ReviewId { get; set; }
        public string UserId { get; set; }
        public UserModel User { get; set; }
        public string BookId { get; set; }
        public BookModel Book { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        
    }
}
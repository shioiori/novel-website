namespace NovelWebsite.Application.Models.Request
{
    public class BookRequest
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int CategoryId { get; set; }
        public string AuthorName {  get; set; }
        public string UserId { get; set; }
        public string Avatar { get; set; } = "default.jpg";
        public string Introduce { get; set; } = String.Empty;
        public string BookStatus { get; set; }
    }
}

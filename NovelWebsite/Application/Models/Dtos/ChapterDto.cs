namespace NovelWebsite.Application.Models.Dtos
{
    public class ChapterDto
    {
        public string ChapterId { get; set; }
        public string BookId { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public string Content { get; set; }
        public int Views { get; set; } = 0;
        public int Likes { get; set; } = 0;
        public string Slug { get; set; }
    }
}

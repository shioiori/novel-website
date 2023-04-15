namespace NovelWebsite.Models
{
    public class FilterModel
    {
        public List<string> BookStatus { get; set; }
        public int CategoryId { get; set; }
        public string Rank { get; set; }
        public List<int> ChapterRange { get; set; }
        public string OrderBy { get; set; }
        public List<int> Tag { get; set; }
    }
}

namespace Application.Models.Objects.Filter
{
    public class BookFilter
    {
        public string SearchName { get; set; }
        public IEnumerable<string> BookStatuses { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
        public IEnumerable<ChapterRange> ChapterRanges { get; set; }
        public IEnumerable<int> TagIds { get; set; }

    }

    public class ChapterRange
    {
        public int MinRange { get; set; }
        public int MaxRange { get; set; }
    }
}

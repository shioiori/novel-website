using NovelWebsite.NovelWebsite.Core.Enums;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class FilterModel
    {
        public IEnumerable<string> BookStatuses { get; set; }
        public IEnumerable<string> UploadStatuses { get; set; }
        public IEnumerable<int> CategoryIds { get; set; }
        public IEnumerable<int> ChapterRange { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        public IEnumerable<int> TagIds { get; set; }
        public InteractionType InteractionType { get; set; }
        public SortOrder OrderBy { get; set; }

    }
}

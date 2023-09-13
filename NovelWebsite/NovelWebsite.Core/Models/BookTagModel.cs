using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class BookTagModel : BaseModel
    {
        public string BookTagId { get; set; }
        public string BookTagName { get; set; }
    }
}

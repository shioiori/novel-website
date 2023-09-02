using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Domain.Models
{
    public class BookTagModel : BaseModel
    {
        public string BookTagId { get; set; }
        public string BookTagName { get; set; }
    }
}

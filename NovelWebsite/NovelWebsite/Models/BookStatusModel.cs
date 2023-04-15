using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class BookStatusModel : BaseModel
    {
        public string BookStatusId { get; set; }
        public string StatusName { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AuthorModel : BaseModel
    {
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}

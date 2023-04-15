using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Models
{
    public class FollowingBookModel : BaseModel
    {
        public string User { get; set; }
        public string Book { get; set; }
    }
}

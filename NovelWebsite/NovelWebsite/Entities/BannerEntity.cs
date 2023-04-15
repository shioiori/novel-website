using NovelWebsite.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Entities
{
    public class BannerEntity : BaseEntity
    {
        [Key]
        public int BannerId { get; set; }
        public string BannerSize { get; set; }
        public string BannerImage { get; set; }

        [ForeignKey("BookId")]
        public int? BookId { get; set; }
        public BookEntity Book { get; set; }
    }
}

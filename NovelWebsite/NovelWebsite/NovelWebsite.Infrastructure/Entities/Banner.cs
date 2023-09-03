using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Banner : BaseEntity
    {
        [Key]
        public int BannerId { get; set; }
        public int BannerType { get; set; }
        public string BannerImage { get; set; }

        [ForeignKey("BookId")]
        public int? BookId { get; set; }
        public Book Book { get; set; }
    }
}

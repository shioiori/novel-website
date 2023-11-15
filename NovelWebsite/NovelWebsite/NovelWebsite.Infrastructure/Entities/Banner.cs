using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class Banner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BannerId { get; set; }
        public int BannerType { get; set; }
        public string BannerImage { get; set; }
        public DateTime ActiveFrom { get; set; } = DateTime.MinValue;
        public DateTime ActiveTo { get; set; } = DateTime.MinValue;

        [ForeignKey("BookId")]
        public string? BookId { get; set; }
        public virtual Book? Book { get; set; }
    }
}

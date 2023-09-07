using NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class BannerModel
    {
        public int BannerId { get; set; }
        public int BannerType { get; set; }
        public string BannerImage { get; set; }
        public DateTime ActiveFrom { get; set; } = DateTime.MinValue;
        public DateTime ActiveTo { get; set; } = DateTime.MinValue;
        public int? BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}

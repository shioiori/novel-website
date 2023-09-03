using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Tag
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string? Slug { get; set; }
    }
}

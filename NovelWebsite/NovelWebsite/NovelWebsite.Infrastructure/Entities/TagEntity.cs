using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Infrastructure.Entities
{
    public class TagEntity
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string? Slug { get; set; }
    }
}

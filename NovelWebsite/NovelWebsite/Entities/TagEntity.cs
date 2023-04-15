using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class TagEntity
    {
        [Key]
        public int TagId { get; set; }
        public string TagName { get; set; }
        public string? Slug { get; set; }
    }
}

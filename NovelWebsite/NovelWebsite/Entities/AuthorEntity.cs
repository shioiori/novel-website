using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class AuthorEntity
    {
        [Key]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string? Slug { get; set; }
    }
}

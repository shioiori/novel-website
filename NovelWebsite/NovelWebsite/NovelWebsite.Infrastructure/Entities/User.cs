using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string? Avatar { get; set; } = String.Empty;
        public string? CoverPhoto { get; set; } = String.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class Interaction
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}

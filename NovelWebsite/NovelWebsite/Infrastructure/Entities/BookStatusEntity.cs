using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Infrastructure.Entities
{
    public class BookStatusEntity
    {
        [Key]
        public string BookStatusId { get; set; }
        public string BookStatusName { get; set; }
    }
}

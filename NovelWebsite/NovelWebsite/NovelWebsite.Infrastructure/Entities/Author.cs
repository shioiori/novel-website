using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string Slug { get; set; }
    }
}

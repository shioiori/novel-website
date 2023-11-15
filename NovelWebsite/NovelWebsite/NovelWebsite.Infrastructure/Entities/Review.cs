using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class Review { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ReviewId { get; set; }
        [ForeignKey("fk_user")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("fk_book")]
        public string BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}

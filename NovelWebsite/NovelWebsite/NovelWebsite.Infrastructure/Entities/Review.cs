using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Review { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }
        [ForeignKey("fk_user")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("fk_book")]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; } = 0;
        public int Dislikes { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;

    }
}

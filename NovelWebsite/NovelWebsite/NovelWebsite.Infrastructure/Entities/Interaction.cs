using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class Interaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InteractionId { get; set; }
        public string InteractionType { get; set; }

        public Interaction() { }
    }
}

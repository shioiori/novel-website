using NovelWebsite.NovelWebsite.NovelWebsite.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class ReviewUsers
    {
        [ForeignKey("fk_ru_user")]
        public string UserId { get; set; }
        [ForeignKey("fk_ru_review")]
        public string ReviewId { get; set; }
        [ForeignKey("fk_ru_interaction")]
        public int InteractionId { get; set; }
        public virtual User User { get; set; }  
        public virtual Review Review { get; set; }
        //public virtual Interaction Interaction { get; set; }

    }
}

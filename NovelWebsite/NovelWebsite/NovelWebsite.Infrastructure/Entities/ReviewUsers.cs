﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class ReviewUsers
    {
        [ForeignKey("fk_ru_user")]
        public int UserId { get; set; }
        [ForeignKey("fk_ru_review")]
        public int ReviewId { get; set; }
        [ForeignKey("fk_ru_interaction")]
        public int InteractType { get; set; }
        public virtual Review Review { get; set; }
    }
}

﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.Infrastructure.Entities
{
    public class Post : BaseEntity
    {
        [Key]
        public int PostId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Content { get; set; }
        public int? Views { get; set; }
        public int? Likes { get; set; }
        public string? Slug { get; set; }
    }
}

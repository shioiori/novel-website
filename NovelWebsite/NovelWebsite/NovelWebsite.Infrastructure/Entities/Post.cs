﻿using NovelWebsite.NovelWebsite.Core.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NovelWebsite.NovelWebsite.Infrastructure.Entities
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string PostId { get; set; }
        [ForeignKey("fk_user")]
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Content { get; set; }
        public int Views { get; set; } = 0;
        public string? Slug { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdatedDate { get; set; } = DateTime.Now;
        public int Status { get; set; } = (int)UploadStatus.Moderation;
    }
}

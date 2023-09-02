﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Infrastructure.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? Quantity { get; set; }
        public string? Slug { get; set; }
        public string? CategoryImage { get; set; }
    }
}

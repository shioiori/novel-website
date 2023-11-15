using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace NovelWebsite.NovelWebsite.Core.Models
{
    public class CategoryModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public int Quantity { get; set; } = 0;
        public string? Slug { get; set; }
    }
}

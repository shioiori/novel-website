using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NovelWebsite.Models
{
    public class CategoryModel : BaseModel
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryImage { get; set; }
        public int Quantity { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelWebsite.Application.Models.Filters
{
    public class ReviewFilter
    {
        [FromQuery(Name = "book")]
        public string? BookId { get; set; }
        [FromQuery(Name = "category")]
        public int? CategoryId { get; set; }
    }
}

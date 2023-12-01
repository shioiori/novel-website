using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Requests;
using NovelWebsite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelWebsite.Application.Models.Filters
{
    public class BannerFilter
    {
        [FromQuery(Name = "type")]
        public BannerType? BannerType { get; set; }
        [FromQuery(Name = "from")]
        public DateTime? ActiveFrom { get; set; } = DateTime.MinValue;
        [FromQuery(Name = "to")]
        public DateTime? ActiveTo { get; set; } = DateTime.MinValue;
    }
}

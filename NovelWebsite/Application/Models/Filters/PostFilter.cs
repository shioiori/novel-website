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
    public class PostFilter
    {
        [FromQuery(Name = "search")]
        public string? SearchName {  get; set; }
        [FromQuery(Name = "status")]
        public UploadStatus? UploadStatus { get; set; }
    }
}

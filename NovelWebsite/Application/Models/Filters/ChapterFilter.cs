using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Filters
{
    public class ChapterFilter
    {
        [FromQuery(Name = "book")]
        public string? BookId {  get; set; }
        [FromQuery(Name = "status")]
        public UploadStatus? UploadStatus { get; set; }
        public PagedListRequest? PagedListRequest { get; set; }
    }
}

using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Application.Models.Request;
using NovelWebsite.Domain.Enums;

namespace Application.Models.Filter
{
    public class BookFilter
    {

        [FromQuery(Name = "seacrh")]
        public string? SearchName { get; set; }

        [FromQuery(Name = "book_status")]
        public IEnumerable<string>? BookStatuses { get; set; }

        [FromQuery(Name = "category")]
        public IEnumerable<int>? CategoryIds { get; set; }

        [FromQuery(Name = "created_min")]
        public DateTime? CreatedMin { get; set; } = DateTime.MinValue;

        [FromQuery(Name = "created_max")]
        public DateTime? CreatedMax { get; set; } = DateTime.MinValue;

        [FromQuery(Name = "updated_min")]
        public DateTime? UpdatedMin { get; set; } = DateTime.MinValue;

        [FromQuery(Name = "updated_max")]
        public DateTime? UpdatedMax { get; set; } = DateTime.MinValue;

        [FromQuery(Name = "min_range")]
        public int? MinRange { get; set; }
        [FromQuery(Name = "max_range")]
        public int? MaxRange { get; set; }

        [FromQuery(Name = "tag")]
        public IEnumerable<int>? TagIds { get; set; }

        [FromQuery(Name = "react")]
        public InteractionType? InteractionType { get; set; }

        [FromQuery(Name = "user")]
        public string? UserId { get; set; } = null;

        [FromQuery(Name = "author")]
        public int? AuthorId { get; set; } = 0;

        [FromQuery(Name = "status")]
        public UploadStatus UploadStatus { get; set; } = NovelWebsite.Domain.Enums.UploadStatus.Publish;

        [FromQuery(Name = "is_deleted")]
        public bool IsDeleted { get; set; } = false;

    }
}

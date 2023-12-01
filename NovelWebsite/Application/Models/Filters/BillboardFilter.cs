using Microsoft.AspNetCore.Mvc;
using NovelWebsite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Filter
{
    public class BillboardFilter
    {

        [FromQuery(Name = "category")]
        public int? CategoryId { get; set; }

        [FromQuery(Name = "react")]
        public InteractionType InteractionType { get; set; } = InteractionType.Like;

        [FromQuery(Name = "sort")]
        public int OrderBy { get; set; } = (int)SortOrder.Descending;
    }
}

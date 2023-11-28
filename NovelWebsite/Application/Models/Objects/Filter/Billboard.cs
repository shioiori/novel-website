using NovelWebsite.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Objects.Filter
{
    public class Billboard
    {
        public int CategoryId { get; set; } = 0;
        public int Reaction { get; set; } = (int)InteractionType.View;
        public int OrderBy { get; set; } = (int)SortOrder.Descending;
    }
}

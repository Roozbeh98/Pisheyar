using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoriesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<PrimaryCategoryDto> PrimaryCategories { get; set; } = new List<PrimaryCategoryDto>();
    }
}

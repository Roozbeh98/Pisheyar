using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoriesVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<PrimaryCategoryDto> PrimaryCategories { get; set; }
    }
}

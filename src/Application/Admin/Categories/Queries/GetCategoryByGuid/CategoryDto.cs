using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }

        public IEnumerable<SubCategoryDto> SubCategories { get; set; }
    }
}

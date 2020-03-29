using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetAllCategories
{
    public class AllCategoriesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<AllCategoryDto> Categories { get; set; } = new List<AllCategoryDto>();
    }
}

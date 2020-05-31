using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public CategoryDtoResult Category { get; set; }
    }
}
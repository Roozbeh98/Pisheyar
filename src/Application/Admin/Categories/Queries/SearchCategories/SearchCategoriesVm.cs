using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.SearchCategories
{
    public class SearchCategoriesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int Count { get; set; }

        public List<SearchCategoriesDto> Categories { get; set; } = new List<SearchCategoriesDto>();
    }
}

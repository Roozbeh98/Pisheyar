using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.SearchCategoriesByCity
{
    public class SearchCategoriesByCityVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public int Count { get; set; }

        public List<SearchCategoriesByCityDto> Categories { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetAllCategoriesName
{
    public class AllCategoriesNameVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<AllCategoriesNameDto> Categories { get; set; }
    }
}

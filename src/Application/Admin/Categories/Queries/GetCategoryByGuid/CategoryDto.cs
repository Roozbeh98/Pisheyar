using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public Guid Guid { get; set; }

        public Guid? ParentGuid { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public List<CategoryDto> Children { get; set; } = new List<CategoryDto>();
    }
}

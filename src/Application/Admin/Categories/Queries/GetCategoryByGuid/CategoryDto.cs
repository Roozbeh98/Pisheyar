using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public List<CategoryDto> Children { get; set; } = new List<CategoryDto>();
    }
}

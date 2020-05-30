using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public string CoverDocument { get; set; }

        public string ActiveIconDocument { get; set; }

        public string InactiveIconDocument { get; set; }

        public string QuadMenuDocument { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<CategoryDto> Children { get; set; }
    }
}

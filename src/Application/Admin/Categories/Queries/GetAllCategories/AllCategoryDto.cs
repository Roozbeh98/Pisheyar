using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System.Collections.Generic;

namespace Pisheyar.Application.Categories.Queries.GetAllCategories
{
    public class AllCategoryDto
    {
        public int CategoryId { get; set; }

        public int? ParentId { get; set; }

        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }

        public List<AllCategoryDto> SubCategories { get; set; } = new List<AllCategoryDto>();
    }
}

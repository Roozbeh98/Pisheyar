using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pisheyar.Application.Categories.Queries.GetAllCategories
{
    public class AllCategoryDto
    {
        public Guid Guid { get; set; }

        //public int? ParentId { get; set; }

        public string Title { get; set; }

        //public int Order { get; set; }

        public List<AllCategoryDto> Children { get; set; } = new List<AllCategoryDto>();
    }
}

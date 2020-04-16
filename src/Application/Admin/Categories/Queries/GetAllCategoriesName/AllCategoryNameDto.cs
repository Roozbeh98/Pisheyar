using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pisheyar.Application.Categories.Queries.GetAllCategoriesName
{
    public class AllCategoryNameDto
    {
        public Guid Guid { get; set; }

        public Guid? ParentGuid { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public List<AllCategoryNameDto> Children { get; set; }
    }
}

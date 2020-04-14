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

        public string Title { get; set; }
    }
}

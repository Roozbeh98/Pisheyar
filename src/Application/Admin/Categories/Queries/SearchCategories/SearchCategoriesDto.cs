﻿using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.SearchCategories
{
    public class SearchCategoriesDto : IMapFrom<TblCategory>
    {
        public Guid CategoryGuid { get; set; }

        public string CategoryDisplay { get; set; }
    }
}

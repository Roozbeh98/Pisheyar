using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.SearchCategoriesByCity
{
    public class SearchCategoriesByCityDto : IMapFrom<Category>
    {
        public Guid CategoryGuid { get; set; }

        public string DisplayName { get; set; }
    }
}

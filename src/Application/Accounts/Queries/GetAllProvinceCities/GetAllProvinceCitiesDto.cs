using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinceCities
{
    public class GetAllProvinceCitiesDto : IMapFrom<City>
    {
        public Guid CityGuid { get; set; }

        public string Name { get; set; }
    }
}

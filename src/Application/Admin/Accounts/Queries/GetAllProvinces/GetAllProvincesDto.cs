using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinces
{
    public class GetAllProvincesDto : IMapFrom<Province>
    {
        public Guid ProvinceGuid { get; set; }

        public string Name { get; set; }
    }
}

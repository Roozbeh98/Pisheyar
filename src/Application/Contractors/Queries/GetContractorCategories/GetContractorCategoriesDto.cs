using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetContractorCategories
{
    public class GetContractorCategoriesDto
    {
        public Guid CategoryGuid { get; set; }

        public string Name { get; set; }
    }
}

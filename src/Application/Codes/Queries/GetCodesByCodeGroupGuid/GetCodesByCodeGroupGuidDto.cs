using System;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Codes.Queries.GetCodesByCodeGroupGuid
{
    public class GetCodesByCodeGroupGuidDto : IMapFrom<Code>
    {
        public Guid CodeGuid { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }
    }
}
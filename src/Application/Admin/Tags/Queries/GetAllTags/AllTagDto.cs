using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Tags.Queries.GetAllTags
{
    public class AllTagDto : IMapFrom<TblTag>
    {
        public Guid TagGuid { get; set; }

        public string TagName { get; set; }
    }
}

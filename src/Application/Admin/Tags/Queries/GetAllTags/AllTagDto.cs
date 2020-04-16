using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Tags.Queries.GetAllTags
{
    public class AllTagDto : IMapFrom<TblTag>
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblTag, AllTagDto>()
                .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.TagGuid))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.TagName));
        }
    }
}

using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinceCities
{
    public class GetAllProvinceCitiesDto : IMapFrom<City>
    {
        public Guid CityGuid { get; set; }

        public string Value { get; set; }

        public string Label { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, GetAllProvinceCitiesDto>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Name));
        }
    }
}

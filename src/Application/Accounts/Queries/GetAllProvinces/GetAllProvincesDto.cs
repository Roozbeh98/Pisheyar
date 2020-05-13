using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Pisheyar.Application.Accounts.Queries.GetAllProvinceCities;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinces
{
    public class GetAllProvincesDto : IMapFrom<Province>
    {
        public Guid ProvinceGuid { get; set; }

        public string Value { get; set; }

        public string Label { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Province, GetAllProvincesDto>()
                .ForMember(d => d.Value, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.Label, opt => opt.MapFrom(s => s.Name));
        }
    }
}

using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoryDto : IMapFrom<Category>
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, PrimaryCategoryDto>()
                .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.CategoryGuid))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.DisplayName))
                .ForMember(d => d.Order, opt => opt.MapFrom(s => s.Sort));
        }
    }
}

using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoryDto : IMapFrom<TblCategory>
    {
        public Guid Guid { get; set; }

        public Guid? ParentGuid { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblCategory, PrimaryCategoryDto>()
                .ForMember(d => d.Guid, opt => opt.MapFrom(s => s.CategoryGuid))
                .ForMember(d => d.ParentGuid, opt => opt.MapFrom(s => s.CategoryCategoryGuid))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.CategoryDisplay))
                .ForMember(d => d.Order, opt => opt.MapFrom(s => s.CategoryOrder));
        }
    }
}

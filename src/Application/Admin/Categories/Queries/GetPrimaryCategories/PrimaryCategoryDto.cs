using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoryDto : IMapFrom<TblCategory>
    {
        public int Id { get; set; }

        public int? ParentId { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblCategory, PrimaryCategoryDto>()
                .ForMember(d => d.Id, opt => opt.MapFrom(s => s.CategoryId))
                .ForMember(d => d.ParentId, opt => opt.MapFrom(s => s.CategoryCategoryId))
                .ForMember(d => d.Title, opt => opt.MapFrom(s => s.CategoryDisplay))
                .ForMember(d => d.Order, opt => opt.MapFrom(s => s.CategoryOrder));
        }
    }
}

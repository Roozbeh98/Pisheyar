using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System.Collections.Generic;

namespace Pisheyar.Application.Categories.Queries.GetAllCategories
{
    public class AllCategoryDto/* : IMapFrom<TblCategory>*/
    {
        public int CategoryId { get; set; }

        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }

        public List<AllCategoryDto> SubCategories { get; set; }/* = new List<AllCategoryDto>();*/

        //public void Mapping(Profile profile)
        //{
        //    profile.CreateMap<TblCategory, AllCategoryDto>()
        //        .ForMember(d => d.SubCategories, opt => opt.MapFrom(s => s.InverseCategoryCategory));
        //}
    }
}

using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoryDto : IMapFrom<TblCategory>
    {
        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }
    }
}

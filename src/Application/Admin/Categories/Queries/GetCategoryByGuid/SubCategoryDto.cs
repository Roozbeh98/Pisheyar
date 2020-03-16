using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class SubCategoryDto : IMapFrom<TblCategory>
    {
        public string CategoryDisplay { get; set; }

        public int CategoryOrder { get; set; }
    }
}

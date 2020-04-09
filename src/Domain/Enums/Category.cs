using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum GetCategoryByGuidState
    {
        Success = 1,
        NotFound = 2
    }

    public enum GetAllCategoriesState
    {
        Success = 1,
        NotFound = 2
    }

    public enum GetPrimaryCategoriesState
    {
        Success = 1,
        NotFound = 2
    }

    public enum DeleteCategoryState
    {
        Success = 1,
        NotFound = 2
    }

    public enum SearchCategoriesState
    {
        Success = 1,
        NotFound = 2
    }
}

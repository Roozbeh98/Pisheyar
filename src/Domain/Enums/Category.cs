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

    public enum GetAllCategoriesNameState
    {
        Success = 1,
        NotFound = 2
    }

    public enum GetPrimaryCategoriesState
    {
        Success = 1,
        NotAnyCategoriesFound = 2,
        CategoryNotFound = 3
    }

    public enum DeleteCategoryState
    {
        Success = 1,
        NotAnyCategoriesFound = 2,
        CategoryNotFound = 3
    }

    public enum SearchCategoriesState
    {
        Success = 1,
        NotFound = 2
    }

    public enum SearchCategoriesByCityState
    {
        Success = 1,
        NotFound = 2
    }

    public enum SetCategoryDetailsState
    {
        Success = 1,
        DocumentGuidProblem = 2,
        CategoryNotFound = 3,
        CoverDocumentNotFound = 4,
        ActiveIconDocumentNotFound = 5,
        InactiveIconDocumentNotFound = 6,
        QuadMenuDocumentNotFound = 7
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum GetContractorCategoriesState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        NotAnyContractorCategoriesFound = 4
    }

    public enum ChangeContractorCityState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        CityNotFound = 4
    }
}

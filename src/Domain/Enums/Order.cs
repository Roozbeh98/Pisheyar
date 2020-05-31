using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum CreateOrderState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        CategoryNotFound = 4,
    }

    public enum FinishOrderState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4,
        OrderNotFound = 5,
        OrderNotAcceptedBefore = 6,
        OrderDoneBefore = 7,
        OrderCancelledBefore = 8,
        OrderRequestAllowedBefore = 9
    }

    public enum GetOrdersForContractorState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        CategoryNotFound = 4,
        NotAnyCategoriesFound = 5,
        NotAnyOrdersFound = 6
    }

    public enum GetClientOrdersState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        StateNotFound = 4,
        NotAnyOrdersFound = 5
    }
}

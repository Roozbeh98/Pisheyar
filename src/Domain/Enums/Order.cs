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
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum AuthenticateState
    {
        Success = 1,
        WrongCode = 2,
        UserNotFound = 3
    }
}

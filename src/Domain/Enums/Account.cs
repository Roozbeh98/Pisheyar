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

    public enum RegisterState
    {
        Success = 1,
        UserExists = 2
    }

    public enum LoginState
    {
        Success = 1,
        UserNotFound = 2,
        UserNotActivated = 3
    }

    public enum DeleteUserState
    {
        Success = 1,
        UserNotFound = 2
    }

    public enum ChangeUserActivenessState
    {
        Success = 1,
        UserNotFound = 2
    }
}

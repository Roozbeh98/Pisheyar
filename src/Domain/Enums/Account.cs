using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum AuthenticateState
    {
        Success = 1,
        WrongCode = 2,
        UserNotFound = 3,
        CodeNotFound = 4
    }

    public enum RegisterClientState
    {
        Success = 1,
        UserExists = 2,
        ClientNotFound = 3,
        CityNotFound = 4
    }

    public enum RegisterContractorState
    {
        Success = 1,
        UserExists = 2,
        GenderNotFound = 3,
        BusinessTypeNotFound = 4,
        CityNotFound = 5,
        ContractorNotFound = 6
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

    public enum GetAllProvinceCitiesState
    {
        Success = 1,
        ProvinceNotFound = 2,
        ProvinceCitiesNotFound = 3
    }

    public enum GetAllProvincesState
    {
        Success = 1,
        ProvinceNotFound = 2
    }

    public enum GetCurrentUserState
    {
        Success = 1,
        UserNotFound = 2
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Domain.Enums
{
    public enum CreateOrderRequestState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        OrderNotFound = 4,
    }

    public enum AcceptOrderRequestState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderRequestNotFound = 4,
    }

    public enum GetOrderRequestsForClientState
    {
        Success = 1,
        UserNotFound = 2,
        ClientNotFound = 3,
        OrderNotFound = 4,
        NotAnyOrderRequestsFound = 5
    }

    public enum GetContractorOrderRequestsState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        StateNotFound = 4,
        NotAnyOrderRequestsFound = 5
    }

    public enum GetChatRoomState
    {
        Success = 1,
        UserNotFound = 2,
        ContractorNotFound = 3,
        NotAnyChatRoomsFound = 4
    }

    public enum GetMessagesState
    {
        Success = 1,
        UserNotFound = 2,
        OrderRequestNotFound = 3,
        NotAnyChatMessagesFound = 4
    }
}
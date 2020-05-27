using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetChatRooms
{
    public class GetChatRoomsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetChatRoomsDto> ChatRooms { get; set; }
    }
}

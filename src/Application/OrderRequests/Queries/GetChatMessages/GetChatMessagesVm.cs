using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetChatMessages
{
    public class GetChatMessagesVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetChatMessagesDto> ChatMessages { get; set; }
    }
}

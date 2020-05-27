using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestsForClient
{
    public class GetOrderRequestsForClientVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetOrderRequestsForClientDto> Orders { get; set; }
    }
}

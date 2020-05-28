using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAllowingStatus
{
    public class GetOrderRequestAllowingStatusVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public bool AllowingStatus { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetContractorOrderRequests
{
    public class GetContractorOrderRequestsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetContractorOrderRequestsDto> OrderRequests { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Orders.Queries.GetOrdersForContractor
{
    public class GetOrdersForContractorVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetOrdersForContractorDto> Orders { get; set; }
    }
}

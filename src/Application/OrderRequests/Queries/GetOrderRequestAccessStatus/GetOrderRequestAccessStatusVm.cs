using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAccessStatus
{
    public class GetOrderRequestAccessStatusVm : IMapFrom<OrderRequest>
    {
        public string Message { get; set; }

        public int State { get; set; }

        public bool AccessStatus { get; set; }
    }
}

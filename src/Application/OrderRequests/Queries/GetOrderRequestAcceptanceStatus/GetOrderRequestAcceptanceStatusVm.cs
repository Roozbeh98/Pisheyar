using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAcceptanceStatus
{
    public class GetOrderRequestAcceptanceStatusVm : IMapFrom<OrderRequest>
    {
        public string Message { get; set; }

        public int State { get; set; }

        public bool AcceptanceStatus { get; set; }
    }
}

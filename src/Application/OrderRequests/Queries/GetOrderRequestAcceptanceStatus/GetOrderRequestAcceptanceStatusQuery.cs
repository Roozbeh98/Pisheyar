using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAcceptanceStatus
{
    public class GetOrderRequestAcceptanceStatusQuery : IRequest<GetOrderRequestAcceptanceStatusVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class GetOrderRequestAcceptanceStatusQueryHandler : IRequestHandler<GetOrderRequestAcceptanceStatusQuery, GetOrderRequestAcceptanceStatusVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetOrderRequestAcceptanceStatusQueryHandler(IPisheyarContext context,
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<GetOrderRequestAcceptanceStatusVm> Handle(GetOrderRequestAcceptanceStatusQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrderRequestAcceptanceStatusVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAcceptanceStatusState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null)
                {
                    return new GetOrderRequestAcceptanceStatusVm()
                    {
                        Message = "سرویس گیرنده مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAcceptanceStatusState.ClientNotFound
                    };
                }

                OrderRequest orderRequest = await _context.OrderRequest
                   .Where(x => x.OrderRequestGuid == request.OrderRequestGuid)
                   .SingleOrDefaultAsync(cancellationToken);

                if (orderRequest == null)
                {
                    return new GetOrderRequestAcceptanceStatusVm()
                    {
                        Message = "درخواست سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAcceptanceStatusState.OrderRequestNotFound
                    };
                }

                return new GetOrderRequestAcceptanceStatusVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestAcceptanceStatusState.Success,
                    AcceptanceStatus = orderRequest.IsAccept
                };
            }
        }
    }
}

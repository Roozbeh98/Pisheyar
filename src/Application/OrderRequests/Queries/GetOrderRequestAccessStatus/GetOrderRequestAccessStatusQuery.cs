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

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAccessStatus
{
    public class GetOrderRequestAccessStatusQuery : IRequest<GetOrderRequestAccessStatusVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class GetOrderRequestAcceptanceStatusQueryHandler : IRequestHandler<GetOrderRequestAccessStatusQuery, GetOrderRequestAccessStatusVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetOrderRequestAcceptanceStatusQueryHandler(IPisheyarContext context,
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<GetOrderRequestAccessStatusVm> Handle(GetOrderRequestAccessStatusQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrderRequestAccessStatusVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null)
                {
                    return new GetOrderRequestAccessStatusVm()
                    {
                        Message = "سرویس گیرنده مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.ClientNotFound
                    };
                }

                OrderRequest orderRequest = await _context.OrderRequest
                   .Where(x => x.OrderRequestGuid == request.OrderRequestGuid)
                   .SingleOrDefaultAsync(cancellationToken);

                if (orderRequest == null)
                {
                    return new GetOrderRequestAccessStatusVm()
                    {
                        Message = "درخواست سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAccessStatusState.OrderRequestNotFound
                    };
                }

                return new GetOrderRequestAccessStatusVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestAccessStatusState.Success,
                    AccessStatus = (orderRequest.Order.StateCodeId == 9 &&
                        orderRequest.IsAllow) ||
                        orderRequest.IsAccept
                };
            }
        }
    }
}

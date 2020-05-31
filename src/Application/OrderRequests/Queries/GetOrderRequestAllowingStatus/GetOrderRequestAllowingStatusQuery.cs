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

namespace Pisheyar.Application.OrderRequests.Queries.GetOrderRequestAllowingStatus
{
    public class GetOrderRequestAllowingStatusQuery : IRequest<GetOrderRequestAllowingStatusVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class GetOrderRequestAcceptanceStatusQueryHandler : IRequestHandler<GetOrderRequestAllowingStatusQuery, GetOrderRequestAllowingStatusVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public GetOrderRequestAcceptanceStatusQueryHandler(IPisheyarContext context,
                ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUser = currentUserService;
            }

            public async Task<GetOrderRequestAllowingStatusVm> Handle(GetOrderRequestAllowingStatusQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetOrderRequestAllowingStatusVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAllowingStatusState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null)
                {
                    return new GetOrderRequestAllowingStatusVm()
                    {
                        Message = "سرویس گیرنده مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAllowingStatusState.ClientNotFound
                    };
                }

                OrderRequest orderRequest = await _context.OrderRequest
                   .Where(x => x.OrderRequestGuid == request.OrderRequestGuid)
                   .SingleOrDefaultAsync(cancellationToken);

                if (orderRequest == null)
                {
                    return new GetOrderRequestAllowingStatusVm()
                    {
                        Message = "درخواست سفارش مورد نظر یافت نشد",
                        State = (int)GetOrderRequestAllowingStatusState.OrderRequestNotFound
                    };
                }

                return new GetOrderRequestAllowingStatusVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetOrderRequestAllowingStatusState.Success,
                    AllowingStatus = orderRequest.IsAllow
                };
            }
        }
    }
}

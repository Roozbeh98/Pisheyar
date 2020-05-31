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

namespace Pisheyar.Application.Orders.Queries.GetClientOrders
{
    public class GetClientOrdersQuery : IRequest<GetClientOrdersVm>
    {
        public Guid? StateGuid { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetClientOrdersQuery, GetClientOrdersVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public OrdersListQueryHandler(IPisheyarContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetClientOrdersVm> Handle(GetClientOrdersQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetClientOrdersVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetClientOrdersState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null)
                {
                    return new GetClientOrdersVm()
                    {
                        Message = "سرویس گیرنده مورد نظر یافت نشد",
                        State = (int)GetClientOrdersState.ClientNotFound
                    };
                }

                IQueryable<Order> orders = _context.Order
                    .Where(x => x.ClientId == client.ClientId)
                    .AsQueryable();

                if (request.StateGuid != null)
                {
                    Code state = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.StateGuid, cancellationToken);

                    if (state == null)
                    {
                        return new GetClientOrdersVm()
                        {
                            Message = "وضعیت مورد نظر یافت نشد",
                            State = (int)GetClientOrdersState.StateNotFound
                        };
                    }

                    orders = orders.Where(x => x.StateCodeId == state.CodeId);
                }

                List<GetClientOrdersDto> ordersResult = await orders
                    .ProjectTo<GetClientOrdersDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (ordersResult.Count <= 0)
                {
                    return new GetClientOrdersVm()
                    {
                        Message = "سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetClientOrdersState.NotAnyOrdersFound
                    };
                }

                return new GetClientOrdersVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetClientOrdersState.Success,
                    Orders = ordersResult
                };
            }
        }
    }
}

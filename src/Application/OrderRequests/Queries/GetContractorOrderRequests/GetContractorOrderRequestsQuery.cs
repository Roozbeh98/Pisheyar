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

namespace Pisheyar.Application.OrderRequests.Queries.GetContractorOrderRequests
{
    public class GetContractorOrderRequestsQuery : IRequest<GetContractorOrderRequestsVm>
    {
        public Guid? StateGuid { get; set; }

        public bool AllowedOnly { get; set; }

        public class OrdersListQueryHandler : IRequestHandler<GetContractorOrderRequestsQuery, GetContractorOrderRequestsVm>
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

            public async Task<GetContractorOrderRequestsVm> Handle(GetContractorOrderRequestsQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetContractorOrderRequestsVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetContractorOrderRequestsState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null)
                {
                    return new GetContractorOrderRequestsVm()
                    {
                        Message = "سرویس دهنده مورد نظر یافت نشد",
                        State = (int)GetContractorOrderRequestsState.ContractorNotFound
                    };
                }

                IQueryable<OrderRequest> orderRequests = _context.OrderRequest
                   .Where(x => x.ContractorId == contractor.ContractorId)
                   .AsQueryable();

                if (request.AllowedOnly)
                {
                    orderRequests = orderRequests.Where(x => x.IsAllow == request.AllowedOnly);
                }

                if (request.StateGuid != null)
                {
                    Code state = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.StateGuid && !x.IsDelete, cancellationToken);

                    if (state == null)
                    {
                        return new GetContractorOrderRequestsVm()
                        {
                            Message = "وضعیت مورد نظر یافت نشد",
                            State = (int)GetContractorOrderRequestsState.StateNotFound
                        };
                    }

                    orderRequests = orderRequests.Where(x => x.Order.StateCodeId == state.CodeId);
                }

                List<GetContractorOrderRequestsDto> orderRequestsResult = await orderRequests
                    .ProjectTo<GetContractorOrderRequestsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (orderRequestsResult.Count <= 0)
                {
                    return new GetContractorOrderRequestsVm()
                    {
                        Message = "درخواست سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetContractorOrderRequestsState.NotAnyOrderRequestsFound
                    };
                }

                return new GetContractorOrderRequestsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetContractorOrderRequestsState.Success,
                    OrderRequests = orderRequestsResult
                };
            }
        }
    }
}

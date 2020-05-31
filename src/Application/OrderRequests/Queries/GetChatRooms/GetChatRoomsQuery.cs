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

namespace Pisheyar.Application.OrderRequests.Queries.GetChatRooms
{
    public class GetChatRoomsQuery : IRequest<GetChatRoomsVm>
    {
        public class OrdersListQueryHandler : IRequestHandler<GetChatRoomsQuery, GetChatRoomsVm>
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

            public async Task<GetChatRoomsVm> Handle(GetChatRoomsQuery request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "سرویس دهنده مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.ContractorNotFound
                    };
                }

                List<GetChatRoomsDto> orderRequests = await _context.OrderRequest
                    .Where(x => x.ContractorId == contractor.ContractorId && x.IsAllow)
                    .ProjectTo<GetChatRoomsDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (orderRequests.Count <= 0)
                {
                    return new GetChatRoomsVm()
                    {
                        Message = "درخواست سفارشی برای کاربر مورد نظر یافت نشد",
                        State = (int)GetChatRoomState.NotAnyChatRoomsFound
                    };
                }

                return new GetChatRoomsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetChatRoomState.Success,
                    ChatRooms = orderRequests
                };
            }
        }
    }
}

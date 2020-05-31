using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Accounts.Commands.RegisterClient;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;

namespace Pisheyar.Application.OrderRequests.Commands.CreateOrderRequest
{
    public class CreateOrderRequestCommand : IRequest<CreateOrderRequestVm>
    {
        public Guid OrderGuid { get; set; }

        public string Message { get; set; }

        public long OfferedPrice { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequestCommand, CreateOrderRequestVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly ISmsService _sms;

            public CreateOrderCommandHandler(IPisheyarContext context, ICurrentUserService currentUserService, ISmsService smsService)
            {
                _context = context;
                _currentUser = currentUserService;
                _sms = smsService;
            }

            public async Task<CreateOrderRequestVm> Handle(CreateOrderRequestCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new CreateOrderRequestVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)CreateOrderRequestState.UserNotFound
                    };
                }

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId && !x.IsDelete, cancellationToken);

                if (contractor == null) return new CreateOrderRequestVm
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)CreateOrderRequestState.ContractorNotFound
                };

                Order order = await _context.Order
                    .SingleOrDefaultAsync(x => x.OrderGuid == request.OrderGuid && !x.IsDelete, cancellationToken);

                if (order == null) return new CreateOrderRequestVm
                {
                    Message = "سفارش مورد نظر یافت نشد",
                    State = (int)CreateOrderRequestState.OrderNotFound
                };

                OrderRequest orderRequest = new OrderRequest
                {
                    ContractorId = contractor.ContractorId,
                    OrderId = order.OrderId,
                    Message = request.Message,
                    OfferedPrice = request.OfferedPrice
                };

                _context.OrderRequest.Add(orderRequest);

                contractor.Credit -= 500;

                await _context.SaveChangesAsync(cancellationToken);

                return new CreateOrderRequestVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateOrderRequestState.Success
                };
            }
        }
    }
}

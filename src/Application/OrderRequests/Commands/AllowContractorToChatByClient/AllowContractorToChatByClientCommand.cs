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

namespace Pisheyar.Application.OrderRequests.Commands.AllowContractorToChatByClient
{
    public class AllowContractorToChatByClientCommand : IRequest<AllowContractorToChatByClientVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<AllowContractorToChatByClientCommand, AllowContractorToChatByClientVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public CreateOrderCommandHandler(IPisheyarContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<AllowContractorToChatByClientVm> Handle(AllowContractorToChatByClientCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new AllowContractorToChatByClientVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)AllowOrderRequestState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId && !x.IsDelete, cancellationToken);

                if (client == null) return new AllowContractorToChatByClientVm
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)AllowOrderRequestState.ClientNotFound
                };

                OrderRequest orderRequest = await _context.OrderRequest
                    .Include(x => x.Order)
                    .SingleOrDefaultAsync(x => x.OrderRequestGuid == request.OrderRequestGuid && !x.IsDelete, cancellationToken);

                if (orderRequest == null) return new AllowContractorToChatByClientVm
                {
                    Message = "درخواست سفارش مورد نظر یافت نشد",
                    State = (int)AllowOrderRequestState.OrderRequestNotFound
                };

                switch (orderRequest.Order.StateCodeId)
                {
                    case 10:
                        return new AllowContractorToChatByClientVm
                        {
                            Message = "سفارش مورد نظر قبول شده است",
                            State = (int)AllowOrderRequestState.OrderRequestAcceptedBefore
                        };

                    case 11:
                        return new AllowContractorToChatByClientVm
                        {
                            Message = "سفارش مورد نظر به اتمام رسیده است",
                            State = (int)AllowOrderRequestState.OrderDoneBefore
                        };

                    case 12:
                        return new AllowContractorToChatByClientVm
                        {
                            Message = "سفارش مورد نظر لغو شده است",
                            State = (int)AllowOrderRequestState.OrderCancelledBefore
                        };
                }

                if (orderRequest.IsAllow) return new AllowContractorToChatByClientVm
                {
                    Message = "سفارش مورد نظر قبلا تایید شده است",
                    State = (int)AllowOrderRequestState.OrderRequestAllowedBefore
                };

                orderRequest.IsAllow = true;
                orderRequest.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new AllowContractorToChatByClientVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)AllowOrderRequestState.Success
                };
            }
        }
    }
}

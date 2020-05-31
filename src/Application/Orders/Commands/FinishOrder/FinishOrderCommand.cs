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

namespace Pisheyar.Application.Orders.Commands.FinishOrder
{
    public class FinishOrderCommand : IRequest<FinishOrderVm>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Comment { get; set; }

        public double Rate { get; set; }

        public int Cost { get; set; }

        public class FinishOrderCommandHandler : IRequestHandler<FinishOrderCommand, FinishOrderVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public FinishOrderCommandHandler(IPisheyarContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            private async Task<double> CalculateAverageRate(int contractorId, double newRate, double? latestAverageRate)
            {
                int contractorOrdersCount = await _context.Order
                    .CountAsync(x => x.ContractorId == contractorId && x.StateCodeId == 11 && !x.IsDelete);

                double contractorAverageRate = latestAverageRate ?? 0f;

                return ((contractorOrdersCount * contractorAverageRate) + newRate) / (contractorOrdersCount + 1);
            }

            public async Task<FinishOrderVm> Handle(FinishOrderCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new FinishOrderVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)FinishOrderState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId && !x.IsDelete, cancellationToken);

                if (client == null) return new FinishOrderVm
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)FinishOrderState.ClientNotFound
                };

                OrderRequest orderRequest = await _context.OrderRequest
                    .Include(x => x.Contractor)
                    .SingleOrDefaultAsync(x => x.OrderRequestGuid == request.OrderRequestGuid && !x.IsDelete, cancellationToken);

                if (orderRequest == null) return new FinishOrderVm
                {
                    Message = "درخواست سفارش مورد نظر یافت نشد",
                    State = (int)FinishOrderState.OrderRequestNotFound
                };

                Order order = await _context.Order
                    .SingleOrDefaultAsync(x => x.OrderId == orderRequest.OrderId && !x.IsDelete, cancellationToken);

                if (order == null) return new FinishOrderVm
                {
                    Message = "سفارش مورد نظر یافت نشد",
                    State = (int)FinishOrderState.OrderNotFound
                };

                switch (order.StateCodeId)
                {
                    case 9:
                        return new FinishOrderVm
                        {
                            Message = "سفارش مورد نظر قبول نشده است",
                            State = (int)FinishOrderState.OrderNotAcceptedBefore
                        };

                    case 11:
                        return new FinishOrderVm
                        {
                            Message = "سفارش مورد نظر به اتمام رسیده است",
                            State = (int)FinishOrderState.OrderDoneBefore
                        };

                    case 12:
                        return new FinishOrderVm
                        {
                            Message = "سفارش مورد نظر لغو شده است",
                            State = (int)FinishOrderState.OrderCancelledBefore
                        };
                }

                if (!orderRequest.IsAllow) return new FinishOrderVm
                {
                    Message = "سفارش مورد نظر تایید نشده است",
                    State = (int)FinishOrderState.OrderRequestAllowedBefore
                };

                order.Comment = request.Comment;
                order.Rate = request.Rate;
                order.Cost = request.Cost;
                order.StateCodeId = 11;
                order.ModifiedDate = DateTime.Now;

                orderRequest.Contractor.AverageRate = await CalculateAverageRate(orderRequest.ContractorId, request.Rate, orderRequest.Contractor.AverageRate);

                await _context.SaveChangesAsync(cancellationToken);

                return new FinishOrderVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)FinishOrderState.Success
                };
            }
        }
    }
}

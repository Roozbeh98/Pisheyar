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

namespace Pisheyar.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<CreateOrderVm>
    {
        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderVm>
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

            public async Task<CreateOrderVm> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new CreateOrderVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)CreateOrderState.UserNotFound
                    };
                }

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId && !x.IsDelete, cancellationToken);

                if (client == null) return new CreateOrderVm
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)CreateOrderState.ClientNotFound
                };

                Category category = await _context.Category
                    .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid && !x.IsDelete, cancellationToken);

                if (category == null) return new CreateOrderVm
                {
                    Message = "دسته بندی مورد نظر یافت نشد",
                    State = (int)CreateOrderState.CategoryNotFound
                };

                Order order = new Order
                {
                    ClientId = client.ClientId,
                    CategoryId = category.CategoryId,
                    StateCodeId = 9,
                    Title = request.Title,
                    Description = request.Description
                };

                _context.Order.Add(order);

                await _context.SaveChangesAsync(cancellationToken);

                List<string> phoneNumbers = await _context.ContractorCategory
                    .Where(x => x.CategoryId == category.CategoryId)
                    .Select(x => x.Contractor.User.PhoneNumber)
                    .ToListAsync(cancellationToken);

                foreach (string phoneNumber in phoneNumbers)
                {
                    object smsResult = await _sms.SendServiceable(Domain.Enums.SmsTemplate.VerifyAccount, phoneNumber, "تست");

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }
                }

                return new CreateOrderVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreateOrderState.Success,
                    SentMessagesCount = phoneNumbers.Count
                };
            }
        }
    }
}

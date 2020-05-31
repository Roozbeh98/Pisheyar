using System;
using System.Collections.Generic;
using System.Text;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Enums;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Pisheyar.Application.Contact.Commands.SendMessage
{
    public class SendMessageCommand : IRequest<SendMessageVm>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid ContactUsBusinessTypeGuid { get; set; }

        public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand, SendMessageVm>
        {
            private readonly IPisheyarContext _context;

            public SendMessageCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<SendMessageVm> Handle(SendMessageCommand request, CancellationToken cancellationToken)
            {
                Code contactUsBusinessType = await _context.Code
                    .SingleOrDefaultAsync(x => x.CodeGuid == request.ContactUsBusinessTypeGuid && !x.IsDelete, cancellationToken);

                if (contactUsBusinessType == null) return new SendMessageVm()
                {
                    Message = "نوع کسب و کار مورد نظر یافت نشد",
                    State = (int)SendContactUsMessgae.CategoryNotFound
                };

                ContactUs contectUs = new ContactUs()
                {
                    Name = request.Name,
                    Email = request.Email,
                    PhoneNumber = request.PhoneNumber,
                    ContactUsBusinessTypeCodeId = contactUsBusinessType.CodeId
                };

                _context.ContactUs.Add(contectUs);

                await _context.SaveChangesAsync(cancellationToken);

                return new SendMessageVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SendContactUsMessgae.Success
                };
            }
        }
    }
}

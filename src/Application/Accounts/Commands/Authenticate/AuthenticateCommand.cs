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

namespace Pisheyar.Application.Accounts.Commands.Authenticate
{
    public class AuthenticateCommand : IRequest<AuthenticateVm>
    {
        public string PhoneNumber { get; set; }

        public string SmsToken{ get; set; }

        public bool RememberMe { get; set; }

        public Guid RoleGuid { get; set; }

        public bool IsApplication { get; set; }

        public class AuthenticateQueryHandler : IRequestHandler<AuthenticateCommand, AuthenticateVm>
        {
            //private readonly IPisheyarMagContext _context;
            private readonly IIdentityService _identityService;
            //private readonly ISmsService _sms;

            public AuthenticateQueryHandler(IPisheyarContext context, IIdentityService identityService, ISmsService smsService)
            {
                //_context = context;
                _identityService = identityService;
                //_sms = smsService;
            }

            public async Task<AuthenticateVm> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
            {
                return await _identityService.Authenticate(request.PhoneNumber, request.SmsToken, request.RoleGuid, request.RememberMe, request.IsApplication);
            }
        }
    }
}

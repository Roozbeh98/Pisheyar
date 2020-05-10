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
        public string Mobile { get; set; }

        public string Code { get; set; }

        public bool RememberMe { get; set; }

        public class AuthenticateQueryHandler : IRequestHandler<AuthenticateCommand, AuthenticateVm>
        {
            //private readonly IPisheyarMagContext _context;
            private readonly IIdentityService _identityService;
            //private readonly ISmsService _smsService;

            public AuthenticateQueryHandler(IPisheyarContext context, IIdentityService identityService, ISmsService smsService)
            {
                //_context = context;
                _identityService = identityService;
                //_smsService = smsService;
            }

            public async Task<AuthenticateVm> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
            {
                return await _identityService.Authenticate(request.Mobile, request.Code, request.RememberMe);
            }
        }
    }
}

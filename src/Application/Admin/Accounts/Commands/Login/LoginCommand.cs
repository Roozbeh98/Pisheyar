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

namespace Pisheyar.Application.Accounts.Commands.Login
{
    public class LoginCommand : IRequest<LoginCommandVm>
    {
        public string Mobile { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ISmsService _smsService;

            public LoginCommandHandler(IPisheyarContext context, ISmsService smsService)
            {
                _context = context;
                _smsService = smsService;
            }

            public async Task<LoginCommandVm> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.User.SingleOrDefaultAsync(x => x.PhoneNumber.Equals(request.Mobile) && !x.IsDelete);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        int token = new Random().Next(100000, 999999);

                        var userToken = new Token
                        {
                            TokenGuid = Guid.NewGuid(),
                            UserId = user.UserId,
                            Value = token,
                            ExpireDate = DateTime.Now.AddMinutes(5)
                        };

                        _context.Token.Add(userToken);

                        await _context.SaveChangesAsync(cancellationToken);

                        object smsResult = await _smsService.SendServiceable(Domain.Enums.SmsTemplate.VerifyAccount, request.Mobile, token.ToString());

                        if (smsResult.GetType().Name != "SendResult")
                        {
                            // sent result
                        }
                        else
                        {
                            // sms error
                        }

                        return new LoginCommandVm() { Message = "عملیات موفق آمیز", State = (int)LoginState.Success };
                    }

                    return new LoginCommandVm() { Message = "حساب کار مورد نظر غیر فعال است", State = (int)LoginState.UserNotActivated };
                }

                return new LoginCommandVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)LoginState.UserNotFound };
            }
        }
    }
}

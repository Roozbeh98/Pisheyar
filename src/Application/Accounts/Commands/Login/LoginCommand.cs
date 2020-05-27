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
        public string PhoneNumber { get; set; }

        public Guid RoleGuid { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ISmsService _sms;

            public LoginCommandHandler(IPisheyarContext context, ISmsService smsService)
            {
                _context = context;
                _sms = smsService;
            }

            public async Task<LoginCommandVm> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                User user = await _context.User
                    .SingleOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber) && !x.IsDelete, cancellationToken);

                if (user == null) return new LoginCommandVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)LoginState.UserNotFound
                };

                bool userExistsInRole;
                int codeId = -1;

                switch (request.RoleGuid.ToString())
                {
                    case "46a09d81-c57f-4655-a8f5-027c66a6cfb1":
                        userExistsInRole = await _context.Admin
                            .AnyAsync(x => x.UserId == user.UserId, cancellationToken);
                        codeId = 13;
                        break;

                    case "91b3cdab-39c1-40fb-b077-a2d6e611f50a":
                        userExistsInRole = await _context.Client
                            .AnyAsync(x => x.UserId == user.UserId, cancellationToken);
                        codeId = 14;
                        break;

                    case "959b10a3-b8ed-4a9d-bdf3-17ec9b2ceb15":
                        userExistsInRole = await _context.Contractor
                            .AnyAsync(x => x.UserId == user.UserId, cancellationToken);
                        codeId = 15;
                        break;

                    default:
                        userExistsInRole = false;
                        break;
                }

                if (!userExistsInRole || codeId == -1) return new LoginCommandVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int) LoginState.UserNotFound
                };

                if (!user.IsRegister) return new LoginCommandVm()
                {
                    Message = "حساب کار مورد نظر غیر فعال است",
                    State = (int) LoginState.UserNotActivated
                };

                //int t = new Random().Next(100000, 999999);
                const int t = 111111;

                Token userToken = new Token
                {
                    TokenGuid = Guid.NewGuid(),
                    RoleCodeId = codeId,
                    UserId = user.UserId,
                    Value = t,
                    ExpireDate = DateTime.Now.AddMinutes(2)
                };

                _context.Token.Add(userToken);

                await _context.SaveChangesAsync(cancellationToken);

                //object smsResult = await _sms.SendServiceable(Domain.Enums.SmsTemplate.VerifyAccount, request.PhoneNumber, t.ToString());

                //if (smsResult.GetType().Name != "SendResult")
                //{
                //    // sent result
                //}
                //else
                //{
                //    // sms error
                //}

                return new LoginCommandVm() { Message = "عملیات موفق آمیز", State = (int)LoginState.Success };

            }
        }
    }
}

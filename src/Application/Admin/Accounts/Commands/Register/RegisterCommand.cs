using System;
using System.Collections.Generic;
using System.Text;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Pisheyar.Application.Accounts.Commands.Register
{
    public class RegisterCommand : IRequest<RegisterCommandVm>
    {
        public string Name { get; set; }

        public string Family { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisterCommandVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly ISmsService _smsService;

            public RegisterCommandHandler(IPisheyarMagContext context, ISmsService smsService)
            {
                _context = context;
                _smsService = smsService;
            }

            public async Task<RegisterCommandVm> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.TblUser.SingleOrDefaultAsync(x => x.UserMobile.Equals(request.Mobile) && !x.UserIsDelete);

                if (user == null)
                {
                    // new user

                    int token = new Random().Next(100000, 999999);

                    var newUser = new TblUser
                    {
                        UserRoleId = (int)Role.User,
                        UserName = request.Name,
                        UserFamily = request.Family,
                        UserEmail = request.Email,
                        UserMobile = request.Mobile
                    };

                    var userToken = new TblUserToken
                    {
                        UtUser = newUser,
                        UtToken = token,
                        UtExpireDate = DateTime.Now.AddMinutes(2)
                    };

                    _context.TblUser.Add(newUser);
                    _context.TblUserToken.Add(userToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    object smsResult = await _smsService.SendServiceable(SmsTemplate.VerifyAccount, request.Mobile, token.ToString());

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }

                    return new RegisterCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterState.Success };
                }
                else
                {
                    // user exists

                    if (user.UserIsActive)
                    {
                        return new RegisterCommandVm() { Message = "کاربر مورد نظر در سامانه ثبت شده است", State = (int)RegisterState.UserExists };
                    }

                    // update existing user

                    DateTime now = DateTime.Now;

                    user.UserName = request.Name;
                    user.UserFamily = request.Family;
                    user.UserEmail = request.Email;
                    user.UserModifyDate = now;

                    int token = new Random().Next(100000, 999999);

                    var userToken = new TblUserToken
                    {
                        UtUserId = user.UserId,
                        UtToken = token,
                        UtExpireDate = now.AddMinutes(2)
                    };

                    _context.TblUserToken.Add(userToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    object smsResult = await _smsService.SendServiceable(SmsTemplate.VerifyAccount, request.Mobile, token.ToString());

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }

                    return new RegisterCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterState.Success };
                }
            }
        }
    }
}

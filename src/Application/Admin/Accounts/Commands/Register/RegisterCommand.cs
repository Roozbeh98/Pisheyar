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
            private readonly IPisheyarContext _context;
            private readonly ISmsService _smsService;

            public RegisterCommandHandler(IPisheyarContext context, ISmsService smsService)
            {
                _context = context;
                _smsService = smsService;
            }

            public async Task<RegisterCommandVm> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.User.SingleOrDefaultAsync(x => x.PhoneNumber.Equals(request.Mobile) && !x.IsDelete);

                if (user == null)
                {
                    // new user

                    int token = new Random().Next(100000, 999999);

                    var newUser = new User
                    {
                        RoleId = (int)Domain.Enums.Role.User,
                        FirstName = request.Name,
                        LastName = request.Family,
                        Email = request.Email,
                        PhoneNumber = request.Mobile
                    };

                    var userToken = new Token
                    {
                        User = newUser,
                        Value = token,
                        ExpireDate = DateTime.Now.AddMinutes(2)
                    };

                    _context.User.Add(newUser);
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

                    return new RegisterCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterState.Success };
                }
                else
                {
                    // user exists

                    if (user.IsActive)
                    {
                        return new RegisterCommandVm() { Message = "کاربر مورد نظر در سامانه ثبت شده است", State = (int)RegisterState.UserExists };
                    }

                    // update existing user

                    DateTime now = DateTime.Now;

                    user.FirstName = request.Name;
                    user.LastName = request.Family;
                    user.Email = request.Email;
                    user.ModifiedDate = now;

                    int token = new Random().Next(100000, 999999);

                    var userToken = new Token
                    {
                        UserId = user.UserId,
                        Value = token,
                        ExpireDate = now.AddMinutes(2)
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

                    return new RegisterCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterState.Success };
                }
            }
        }
    }
}

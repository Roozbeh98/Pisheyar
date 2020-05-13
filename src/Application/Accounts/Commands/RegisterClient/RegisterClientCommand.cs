using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Pisheyar.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Pisheyar.Application.Accounts.Commands.RegisterClient
{
    public class RegisterClientCommand : IRequest<RegisterClientCommandVm>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid CityGuid { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterClientCommand, RegisterClientCommandVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ISmsService _smsService;

            public RegisterCommandHandler(IPisheyarContext context, ISmsService smsService)
            {
                _context = context;
                _smsService = smsService;
            }

            public async Task<RegisterClientCommandVm> Handle(RegisterClientCommand request, CancellationToken cancellationToken)
            {
                User user = await _context.User
                    .SingleOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber) && !x.IsDelete, cancellationToken);

                if (user == null)
                {
                    City city = await _context.City
                        .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                    if (city == null)
                    {
                        return new RegisterClientCommandVm() { Message = "اطلاعات مکانی نامعتبر است", State = (int)RegisterContractorState.CityNotFound };
                    }

                    int t = new Random().Next(100000, 999999);

                    User newUser = new User
                    {
                        RoleId = (int)Domain.Enums.Role.Admin,
                        //GenderCodeId = ,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber
                    };

                    Client client = new Client()
                    {
                        User = newUser,
                        CityId = city.CityId
                    };

                    Token userToken = new Token
                    {
                        User = newUser,
                        Value = t,
                        ExpireDate = DateTime.Now.AddMinutes(2)
                    };

                    _context.User.Add(newUser);
                    _context.Client.Add(client);
                    _context.Token.Add(userToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    object smsResult = await _smsService.SendServiceable(Domain.Enums.SmsTemplate.VerifyAccount, request.PhoneNumber, t.ToString());

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }

                    return new RegisterClientCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterClientState.Success };
                }
                else
                {
                    if (user.IsRegister)
                    {
                        return new RegisterClientCommandVm() { Message = "کاربر مورد نظر در سامانه ثبت شده است", State = (int)RegisterClientState.UserExists };
                    }

                    City city = await _context.City
                        .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                    if (city == null)
                    {
                        return new RegisterClientCommandVm() { Message = "اطلاعات مکانی نامعتبر است", State = (int)RegisterClientState.CityNotFound };
                    }

                    DateTime now = DateTime.Now;

                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    //user.GenderCodeId = gender.CodeId;
                    user.Email = request.Email;
                    user.ModifiedDate = now;

                    Client client = await _context.Client
                        .Where(x => x.UserId == user.UserId && !x.IsDelete)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (client == null)
                    {
                        return new RegisterClientCommandVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)RegisterClientState.ClientNotFound };
                    }

                    client.CityId = city.CityId;
                    client.ModifiedDate = now;

                    int t = new Random().Next(100000, 999999);

                    Token userToken = new Token
                    {
                        UserId = user.UserId,
                        Value = t,
                        ExpireDate = now.AddMinutes(2)
                    };

                    _context.Token.Add(userToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    object smsResult = await _smsService.SendServiceable(Domain.Enums.SmsTemplate.VerifyAccount, request.PhoneNumber, t.ToString());

                    if (smsResult.GetType().Name != "SendResult")
                    {
                        // sent result
                    }
                    else
                    {
                        // sms error
                    }

                    return new RegisterClientCommandVm() { Message = "عملیات موفق آمیز", State = (int)RegisterClientState.Success };
                }
            }
        }
    }
}

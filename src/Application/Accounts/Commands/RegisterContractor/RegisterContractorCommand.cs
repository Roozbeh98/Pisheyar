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
using Pisheyar.Application.Accounts.Commands.RegisterClient;

namespace Pisheyar.Application.Accounts.Commands.RegisterContractor
{
    public class RegisterContractorCommand : IRequest<RegisterContractorVm>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid GenderGuid { get; set; }

        public Guid[] CategoriesGuid { get; set; }

        public Guid BusinessTypeGuid { get; set; }

        public Guid CityGuid { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public class RegisterContractorHandler : IRequestHandler<RegisterContractorCommand, RegisterContractorVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ISmsService _sms;

            public RegisterContractorHandler(IPisheyarContext context, ISmsService smsService)
            {
                _context = context;
                _sms = smsService;
            }

            public async Task<RegisterContractorVm> Handle(RegisterContractorCommand request, CancellationToken cancellationToken)
            {
                User user = await _context.User
                    .SingleOrDefaultAsync(x => x.PhoneNumber.Equals(request.PhoneNumber) && !x.IsDelete, cancellationToken);

                if (user == null)
                {
                    Code gender = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.GenderGuid, cancellationToken);

                    if (gender == null)
                    {
                        return new RegisterContractorVm() { Message = "جنسیت نامعتبر است", State = (int)RegisterContractorState.GenderNotFound };
                    }

                    Code business = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.BusinessTypeGuid, cancellationToken);

                    if (business == null)
                    {
                        return new RegisterContractorVm() { Message = "نوع کسب و کار نامعتبر است", State = (int)RegisterContractorState.BusinessTypeNotFound };
                    }

                    City city = await _context.City
                        .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                    if (city == null)
                    {
                        return new RegisterContractorVm() { Message = "اطلاعات مکانی نامعتبر است", State = (int)RegisterContractorState.CityNotFound };
                    }

                    //int t = new Random().Next(100000, 999999);
                    const int t = 111111;

                    User newUser = new User
                    {
                        RoleId = (int)Domain.Enums.Role.Contractor,
                        GenderCodeId = gender.CodeId,
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        Email = request.Email,
                        PhoneNumber = request.PhoneNumber
                    };

                    Contractor contractor = new Contractor()
                    {
                        User = newUser,
                        BusinessTypeCodeId = business.CodeId,
                        CityId = city.CityId,
                        Latitude = request.Latitude,
                        Longitude = request.Longitude,
                        Credit = 0
                    };

                    foreach (Guid categoryGuid in request.CategoriesGuid)
                    {
                        Category category = await _context.Category
                            .Where(x => x.CategoryGuid == categoryGuid)
                            .SingleOrDefaultAsync(cancellationToken);

                        if (category == null) continue;

                        ContractorCategory contractorCategory = new ContractorCategory()
                        {
                            Contractor = contractor,
                            CategoryId = category.CategoryId
                        };

                        _context.ContractorCategory.Add(contractorCategory);
                    }

                    Token token = new Token
                    {
                        User = newUser,
                        RoleCodeId = 15,
                        Value = t,
                        ExpireDate = DateTime.Now.AddMinutes(2)
                    };

                    _context.User.Add(newUser);
                    _context.Contractor.Add(contractor);
                    _context.Token.Add(token);

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

                    return new RegisterContractorVm() { Message = "عملیات موفق آمیز", State = (int)RegisterContractorState.Success };
                }
                else
                {
                    if (user.IsRegister)
                    {
                        return new RegisterContractorVm() { Message = "کاربر مورد نظر در سامانه ثبت شده است", State = (int)RegisterContractorState.UserExists };
                    }

                    Code gender = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.GenderGuid, cancellationToken);

                    if (gender == null)
                    {
                        return new RegisterContractorVm() { Message = "جنسیت نامعتبر است", State = (int)RegisterContractorState.GenderNotFound };
                    }

                    Code business = await _context.Code
                        .SingleOrDefaultAsync(x => x.CodeGuid == request.BusinessTypeGuid, cancellationToken);

                    if (business == null)
                    {
                        return new RegisterContractorVm() { Message = "نوع کسب و کار نامعتبر است", State = (int)RegisterContractorState.BusinessTypeNotFound };
                    }

                    City city = await _context.City
                        .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                    if (city == null)
                    {
                        return new RegisterContractorVm() { Message = "اطلاعات مکانی نامعتبر است", State = (int)RegisterContractorState.CityNotFound };
                    }

                    DateTime now = DateTime.Now;

                    user.FirstName = request.FirstName;
                    user.LastName = request.LastName;
                    user.GenderCodeId = gender.CodeId;
                    user.Email = request.Email;
                    user.ModifiedDate = now;

                    Contractor contractor = await _context.Contractor
                        .Where(x => x.UserId == user.UserId && !x.IsDelete)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (contractor == null)
                    {
                        return new RegisterContractorVm() { Message = "کاربر مورد نظر یافت نشد", State = (int)RegisterContractorState.ContractorNotFound };
                    }

                    contractor.BusinessTypeCodeId = business.CodeId;
                    contractor.CityId = city.CityId;
                    contractor.Latitude = request.Latitude;
                    contractor.Longitude = request.Longitude;
                    contractor.ModifiedDate = now;

                    List<ContractorCategory> oldCategories = await _context.ContractorCategory
                        .Where(x => x.ContractorId == contractor.ContractorId)
                        .ToListAsync(cancellationToken);

                    foreach (ContractorCategory oldCategory in oldCategories)
                    {
                        _context.ContractorCategory.Remove(oldCategory);
                    }

                    foreach (Guid categoryGuid in request.CategoriesGuid)
                    {
                        Category category = await _context.Category
                            .Where(x => x.CategoryGuid == categoryGuid)
                            .SingleOrDefaultAsync(cancellationToken);

                        if (category == null) continue;

                        ContractorCategory contractorCategory = new ContractorCategory()
                        {
                            Contractor = contractor,
                            CategoryId = category.CategoryId
                        };

                        _context.ContractorCategory.Add(contractorCategory);
                    }

                    //int t = new Random().Next(100000, 999999);
                    const int t = 111111;

                    Token token = new Token
                    {
                        UserId = user.UserId,
                        RoleCodeId = 15,
                        Value = t,
                        ExpireDate = now.AddMinutes(2)
                    };

                    _context.Token.Add(token);

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

                    return new RegisterContractorVm() { Message = "عملیات موفق آمیز", State = (int)RegisterContractorState.Success };
                }
            }
        }
    }
}

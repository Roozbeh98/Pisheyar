using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.Contractors.Commands.ChangeContractorCity
{
    public class ChangeContractorCityCommand : IRequest<ChangeContractorCityVm>
    {
        public Guid CityGuid { get; set; }

        public class ChangeContractorCityCommandHandler : IRequestHandler<ChangeContractorCityCommand, ChangeContractorCityVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public ChangeContractorCityCommandHandler(IPisheyarContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<ChangeContractorCityVm> Handle(ChangeContractorCityCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new ChangeContractorCityVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)ChangeContractorCityState.UserNotFound
                };

                Contractor contractor = await _context.Contractor
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (contractor == null) return new ChangeContractorCityVm()
                {
                    Message = "سرویس دهنده مورد نظر یافت نشد",
                    State = (int)ChangeContractorCityState.ContractorNotFound
                };

                City city = await _context.City
                    .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                if (city == null) return new ChangeContractorCityVm()
                {
                    Message = "اطلاعات مکانی نامعتبر است",
                    State = (int)ChangeContractorCityState.CityNotFound
                };

                contractor.CityId = city.CityId;
                contractor.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeContractorCityVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ChangeContractorCityState.Success
                };
            }
        }
    }
}

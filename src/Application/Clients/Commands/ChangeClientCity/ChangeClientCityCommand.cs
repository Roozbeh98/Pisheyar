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

namespace Pisheyar.Application.Contractors.Commands.ChangeClientCity
{
    public class ChangeClientCityCommand : IRequest<ChangeClientCityVm>
    {
        public Guid CityGuid { get; set; }

        public class ChangeContractorCityCommandHandler : IRequestHandler<ChangeClientCityCommand, ChangeClientCityVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;

            public ChangeContractorCityCommandHandler(IPisheyarContext context, ICurrentUserService currentUser)
            {
                _context = context;
                _currentUser = currentUser;
            }

            public async Task<ChangeClientCityVm> Handle(ChangeClientCityCommand request, CancellationToken cancellationToken)
            {
                User currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null) return new ChangeClientCityVm()
                {
                    Message = "کاربر مورد نظر یافت نشد",
                    State = (int)ChangeClientCityState.UserNotFound
                };

                Client client = await _context.Client
                    .SingleOrDefaultAsync(x => x.UserId == currentUser.UserId, cancellationToken);

                if (client == null) return new ChangeClientCityVm()
                {
                    Message = "سرویس گیرنده مورد نظر یافت نشد",
                    State = (int)ChangeClientCityState.ClientNotFound
                };

                City city = await _context.City
                    .SingleOrDefaultAsync(x => x.CityGuid == request.CityGuid, cancellationToken);

                if (city == null) return new ChangeClientCityVm()
                {
                    Message = "اطلاعات مکانی نامعتبر است",
                    State = (int)ChangeClientCityState.CityNotFound
                };

                client.CityId = city.CityId;
                client.ModifiedDate = DateTime.Now;

                await _context.SaveChangesAsync(cancellationToken);

                return new ChangeClientCityVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)ChangeClientCityState.Success
                };
            }
        }
    }
}

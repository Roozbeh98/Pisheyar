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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Pisheyar.Application.Accounts.Queries.GetAllProvinceCities
{
    public class GetAllProvinceCitiesQuery : IRequest<GetAllProvinceCitiesVm>
    {
        public Guid ProvinceGuid { get; set; }

        public class GetAllProvinceCitiesQueryHandler : IRequestHandler<GetAllProvinceCitiesQuery, GetAllProvinceCitiesVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetAllProvinceCitiesQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllProvinceCitiesVm> Handle(GetAllProvinceCitiesQuery request, CancellationToken cancellationToken)
            {
                var province = await _context.Province
                    .Where(x => x.ProvinceGuid == request.ProvinceGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (province == null)
                {
                    return new GetAllProvinceCitiesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetAllProvinceCitiesState.ProvinceNotFound
                    };
                }

                var cities = await _context.City
                    .Where(x => x.ProvinceId == province.ProvinceId)
                    .OrderBy(x => x.Name)
                    .ProjectTo<GetAllProvinceCitiesDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (cities == null)
                {
                    return new GetAllProvinceCitiesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetAllProvinceCitiesState.ProvinceCitiesNotFound
                    };
                }

                return new GetAllProvinceCitiesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllProvinceCitiesState.Success,
                    Cities = cities
                };
            }
        }
    }
}

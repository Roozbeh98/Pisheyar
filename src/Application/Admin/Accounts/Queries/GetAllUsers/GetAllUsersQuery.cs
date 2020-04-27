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

namespace Pisheyar.Application.Accounts.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<AllUsersVm>
    {
        public class GetUsersQueryHandler : IRequestHandler<GetAllUsersQuery, AllUsersVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetUsersQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AllUsersVm> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                var users = await _context.User
                    .Where(x => !x.IsDelete)
                    .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new AllUsersVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Users = users
                };
            }
        }
    }
}

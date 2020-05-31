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

namespace Pisheyar.Application.Accounts.Queries.GetCurrentClientUser
{
    public class GetCurrentClientUserQuery : IRequest<GetCurrentClientUserVm>
    {
        public class GetUserByGuidQueryHandler : IRequestHandler<GetCurrentClientUserQuery, GetCurrentClientUserVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUser;
            private readonly IMapper _mapper;

            public GetUserByGuidQueryHandler(IPisheyarContext context, ICurrentUserService currentUserService, IMapper mapper)
            {
                _context = context;
                _currentUser = currentUserService;
                _mapper = mapper;
            }

            public async Task<GetCurrentClientUserVm> Handle(GetCurrentClientUserQuery request, CancellationToken cancellationToken)
            {
                GetCurrentClientUserDto user = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUser.NameIdentifier) && x.Client.Count > 0)
                    .ProjectTo<GetCurrentClientUserDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (user == null)
                {
                    return new GetCurrentClientUserVm()
                    {
                        Message = "کاربری یافت نشد",
                        State = (int)GetCurrentUserState.UserNotFound
                    };
                }

                return new GetCurrentClientUserVm()
                {
                    Message ="عملیات موفق آمیز",
                    State = (int)GetCurrentUserState.Success,
                    User = user
                };
            }
        }
    }
}

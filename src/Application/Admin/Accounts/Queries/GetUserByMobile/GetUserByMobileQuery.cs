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

namespace Pisheyar.Application.Accounts.Queries.GetUserByMobile
{
    public class GetUserByMobileQuery : IRequest<UserByMobileVm>
    {
        public string Mobile { get; set; }

        public class GetUserByMobileQueryHandler : IRequestHandler<GetUserByMobileQuery, UserByMobileVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetUserByMobileQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<UserByMobileVm> Handle(GetUserByMobileQuery request, CancellationToken cancellationToken)
            {
                var user = await _context.User
                    .Where(x => x.PhoneNumber.Equals(request.Mobile) && !x.IsDelete)
                    .ProjectTo<UserByMobileDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                bool userExists = user != null;

                return new UserByMobileVm()
                {
                    Message = userExists ? "عملیات موفق آمیز" : "کاربری یافت نشد",
                    Result = userExists ? true : false,
                    User = user
                };
            }
        }
    }
}

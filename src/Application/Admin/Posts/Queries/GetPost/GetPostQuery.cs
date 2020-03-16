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

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostQuery : IRequest<GetPostVm>
    {
        public Guid Guid { get; set; }

        public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetPostQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetPostVm> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.TblPost
                    .Where(x => x.PostGuid == request.Guid && !x.PostIsDelete)
                    .ProjectTo<GetPostDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                return new GetPostVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Post = post
                };
            }
        }
    }
}

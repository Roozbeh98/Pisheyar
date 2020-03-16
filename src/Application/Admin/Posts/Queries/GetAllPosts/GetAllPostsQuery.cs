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

namespace Pisheyar.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<GetAllPostVm>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetAllPostsQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllPostVm> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await _context.TblPost
                    .Where(x => !x.PostIsDelete)
                    .OrderByDescending(x => x.PostModifyDate)
                    .ProjectTo<GetAllPostDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new GetAllPostVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Posts = posts
                };
            }
        }
    }
}

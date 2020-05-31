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

namespace Pisheyar.Application.Posts.Queries.GetPostsByPagination
{
    public class GetPostsByPaginationQuery : IRequest<GetPostsByPaginationVm>
    {
        public int Page { get; set; }

        public class GetAllPostsQueryHandler : IRequestHandler<GetPostsByPaginationQuery, GetPostsByPaginationVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetAllPostsQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetPostsByPaginationVm> Handle(GetPostsByPaginationQuery request, CancellationToken cancellationToken)
            {
                var posts = await _context.Post
                    .Where(x => !x.IsDelete)
                    .OrderByDescending(x => x.ModifiedDate)
                    .Skip(12 * (request.Page - 1))
                    .Take(12)
                    .ProjectTo<GetPostsByPaginationDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new GetPostsByPaginationVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Posts = posts
                };
            }
        }
    }
}

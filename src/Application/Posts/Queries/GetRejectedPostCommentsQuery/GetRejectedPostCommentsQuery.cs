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

namespace Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery
{
    public class GetRejectedPostCommentsQuery : IRequest<RejectedPostCommentsVm>
    {
        public Guid PostGuid { get; set; }

        public class GetRejectedPostCommentsQueryHandler : IRequestHandler<GetRejectedPostCommentsQuery, RejectedPostCommentsVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetRejectedPostCommentsQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RejectedPostCommentsVm> Handle(GetRejectedPostCommentsQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Post
                    .Where(x => x.PostGuid == request.PostGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (post == null)
                {
                    return new RejectedPostCommentsVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        Result = false
                    };
                }
                
                var comments = await _context.PostComment
                    .Where(x => x.PostId == post.PostId && !x.IsAccept)
                    .ProjectTo<RejectedPostCommentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new RejectedPostCommentsVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    PostComments = comments
                };
            }
        }
    }
}

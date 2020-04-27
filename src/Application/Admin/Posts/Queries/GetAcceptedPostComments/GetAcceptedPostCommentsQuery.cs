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

namespace Pisheyar.Application.Posts.Queries.GetAcceptedPostComments
{
    public class GetAcceptedPostCommentsQuery : IRequest<AcceptedPostCommentsVm>
    {
        public Guid PostGuid { get; set; }

        public class GetAcceptedPostCommentsQueryHandler : IRequestHandler<GetAcceptedPostCommentsQuery, AcceptedPostCommentsVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetAcceptedPostCommentsQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AcceptedPostCommentsVm> Handle(GetAcceptedPostCommentsQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Post
                    .Where(x => x.PostGuid == request.PostGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (post == null)
                {
                    return new AcceptedPostCommentsVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        Result = false
                    };
                }

                var comments = await _context.PostComment
                    .Where(x => x.PostId == post.PostId && x.IsAccept)
                    .ProjectTo<AcceptedPostCommentDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                return new AcceptedPostCommentsVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    PostComments = comments
                };
            }
        }
    }
}

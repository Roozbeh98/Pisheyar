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
        public int PostId { get; set; }

        public class GetAcceptedPostCommentsQueryHandler : IRequestHandler<GetAcceptedPostCommentsQuery, AcceptedPostCommentsVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetAcceptedPostCommentsQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AcceptedPostCommentsVm> Handle(GetAcceptedPostCommentsQuery request, CancellationToken cancellationToken)
            {
                var comments = await _context.TblPostComment
                    .Where(x => x.PcPostId == request.PostId && x.PcIsAccept)
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

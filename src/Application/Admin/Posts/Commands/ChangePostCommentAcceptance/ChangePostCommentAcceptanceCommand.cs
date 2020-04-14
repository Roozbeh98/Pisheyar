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

namespace Pisheyar.Application.Posts.Commands.ChangePostCommentAcceptance
{
    public class ChangePostCommentAcceptanceCommand : IRequest<int>
    {
        public Guid PostCommentGuid { get; set; }

        public bool IsAccept { get; set; }

        public class ChangePostCommentAcceptanceCommandHandler : IRequestHandler<ChangePostCommentAcceptanceCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public ChangePostCommentAcceptanceCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(ChangePostCommentAcceptanceCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblPostComment.SingleOrDefaultAsync(x => x.PcGuid == request.PostCommentGuid);

                if (query != null)
                {
                    query.PcIsAccept = request.IsAccept;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}

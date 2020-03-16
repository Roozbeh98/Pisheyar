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

namespace Pisheyar.Application.Posts.Commands.DeletePostComment
{
    public class DeletePostCommentCommand : IRequest<int>
    {
        public int PostCommentId { get; set; }

        public class DeletePostCommentCommandHandler : IRequestHandler<DeletePostCommentCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public DeletePostCommentCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
            {
                var postComment = await _context.TblPostComment
                    .SingleOrDefaultAsync(x => x.PcId == request.PostCommentId, cancellationToken);

                if (postComment != null)
                {
                    var comment = await _context.TblComment
                        .SingleOrDefaultAsync(x => x.CommentId == postComment.PcCommentId, cancellationToken);

                    if (comment != null)
                    {
                        _context.TblPostComment.Remove(postComment);
                        _context.TblComment.Remove(comment);

                        await _context.SaveChangesAsync(cancellationToken);

                        return 1;
                    }
                }

                return -1;
            }
        }
    }
}

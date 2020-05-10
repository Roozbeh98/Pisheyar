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
        public Guid PostCommentGuid { get; set; }

        public class DeletePostCommentCommandHandler : IRequestHandler<DeletePostCommentCommand, int>
        {
            private readonly IPisheyarContext _context;

            public DeletePostCommentCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeletePostCommentCommand request, CancellationToken cancellationToken)
            {
                var postComment = await _context.PostComment
                    .SingleOrDefaultAsync(x => x.PostCommentGuid == request.PostCommentGuid, cancellationToken);

                if (postComment != null)
                {
                    var comment = await _context.Comment
                        .SingleOrDefaultAsync(x => x.CommentGuid == postComment.PostCommentGuid, cancellationToken);

                    if (comment != null)
                    {
                        _context.PostComment.Remove(postComment);
                        _context.Comment.Remove(comment);

                        await _context.SaveChangesAsync(cancellationToken);

                        return 1;
                    }
                }

                return -1;
            }
        }
    }
}

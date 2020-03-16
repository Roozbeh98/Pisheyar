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

namespace Pisheyar.Application.Posts.Commands.CreatePostComment
{
    public class CreatePostCommentCommand : IRequest<int>
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

        public string Text { get; set; }

        public bool IsAccept { get; set; }

        public class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public CreatePostCommentCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
            {
                var commentEntity = new TblComment
                {
                    CommentUserId = request.UserId,
                    CommentText = request.Text
                };

                var postCommentEntity = new TblPostComment
                {
                    PcPostId = request.PostId,
                    PcComment = commentEntity,
                    PcIsAccept = request.IsAccept
                };

                _context.TblComment.Add(commentEntity);
                _context.TblPostComment.Add(postCommentEntity);

                await _context.SaveChangesAsync(cancellationToken);

                return 1;
            }
        }
    }
}

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
        public Guid PostGuid { get; set; }

        public Guid UserGuid { get; set; }

        public string Text { get; set; }

        public bool IsAccept { get; set; }

        public class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, int>
        {
            private readonly IPisheyarContext _context;

            public CreatePostCommentCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreatePostCommentCommand request, CancellationToken cancellationToken)
            {
                var user = await _context.User
                    .Where(x => x.UserGuid == request.UserGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (user != null)
                {
                    var commentEntity = new Comment
                    {
                        UserId = user.UserId,
                        Message = request.Text
                    };

                    var post = await _context.Post
                        .Where(x => x.PostGuid == request.PostGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (post != null)
                    {
                        var postCommentEntity = new PostComment
                        {
                            PostId = post.PostId,
                            Comment = commentEntity,
                            IsAccept = request.IsAccept
                        };

                        _context.Comment.Add(commentEntity);
                        _context.PostComment.Add(postCommentEntity);

                        await _context.SaveChangesAsync(cancellationToken);

                        return 1;
                    }

                    return -2;
                }

                return -1;
            }
        }
    }
}

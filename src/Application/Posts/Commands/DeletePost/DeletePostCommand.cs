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

namespace Pisheyar.Application.Posts.Commands.DeletePost
{
    public class DeletePostCommand : IRequest<DeletePostCommandVm>
    {
        public Guid PostGuid { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeletePostCommand, DeletePostCommandVm>
        {
            private readonly IPisheyarContext _context;

            public DeleteCategoryCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<DeletePostCommandVm> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _context.Post
                    .SingleOrDefaultAsync(x => x.PostGuid == request.PostGuid && !x.IsDelete);

                if (post == null)
                {
                    return new DeletePostCommandVm
                    {
                        Message = "پست مورد نظر یافت نشد",
                        State = (int)DeletePostState.PostNotFound
                    };
                }

                post.IsDelete = true;

                await _context.SaveChangesAsync(cancellationToken);

                return new DeletePostCommandVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)DeletePostState.Success
                };
            }
        }
    }
}

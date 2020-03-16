﻿using System;
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
    public class DeletePostCommand : IRequest<int>
    {
        public int PostId { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeletePostCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public DeleteCategoryCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblPost.SingleOrDefaultAsync(x => x.PostId == request.PostId && !x.PostIsDelete);

                if (query != null)
                {
                    query.PostIsDelete = true;
                    query.PostModifyDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}
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

namespace Pisheyar.Application.Posts.Commands.ChangePostShow
{
    public class ChangePostShowCommand : IRequest<int>
    {
        public Guid PostGuid { get; set; }

        public bool IsShow { get; set; }

        public class ChangePostActivenessCommandHandler : IRequestHandler<ChangePostShowCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public ChangePostActivenessCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(ChangePostShowCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblPost.SingleOrDefaultAsync(x => x.PostGuid == request.PostGuid && !x.PostIsDelete);

                if (query != null)
                {
                    query.PostIsShow = request.IsShow;
                    query.PostModifyDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}

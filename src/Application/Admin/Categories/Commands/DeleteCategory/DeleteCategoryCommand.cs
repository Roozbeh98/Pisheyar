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

namespace Pisheyar.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<int>
    {
        public int CategoryId { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public DeleteCategoryCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblCategory.SingleOrDefaultAsync(x => x.CategoryId == request.CategoryId && !x.CategoryIsDelete);

                if (query != null)
                {
                    query.CategoryIsDelete = true;
                    query.CategoryModifyDate = DateTime.Now;

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                // Delete children too!
                // Update parameter -_-

                return -1;
            }
        }
    }
}

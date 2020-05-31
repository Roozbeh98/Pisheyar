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

namespace Pisheyar.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public Guid? CategoryGuid { get; set; }

        public string Name { get; set; }

        public int Order { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IPisheyarContext _context;

            public CreateCategoryCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var parent = await _context.Category
                    .Where(x => x.CategoryGuid == request.CategoryGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (parent != null)
                {
                    var category = new Category
                    {
                        ParentCategoryId = parent.CategoryId,
                        DisplayName = request.Name,
                        Sort = request.Order,
                    };

                    _context.Category.Add(category);

                    await _context.SaveChangesAsync(cancellationToken);

                    return 1;
                }

                return -1;
            }
        }
    }
}

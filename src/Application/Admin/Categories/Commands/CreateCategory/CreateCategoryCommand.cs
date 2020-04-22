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

        //public Guid BannerDocumentGuid { get; set; }

        //public Guid IconDocumentGuid { get; set; }

        //public Guid[] Tags { get; set; }

        public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public CreateCategoryCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = new TblCategory
                {
                    CategoryCategoryGuid = request.CategoryGuid,
                    CategoryDisplay = request.Name,
                    CategoryOrder = request.Order,
                };

                //foreach (var tagGuid in request.Tags)
                //{
                //    var categoryTag = new TblCategoryTag()
                //    {
                //        CtCategoryGu = category,
                //        CtTagGuid = tagGuid
                //    };

                //    _context.TblCategoryTag.Add(categoryTag);
                //}

                _context.TblCategory.Add(category);

                await _context.SaveChangesAsync(cancellationToken);

                return 1;
            }
        }
    }
}

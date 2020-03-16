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
using AutoMapper.QueryableExtensions;
using AutoMapper;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class GetCategoryByGuidQuery : IRequest<CategoryVm>
    {
        public Guid CategoryGuid { get; set; }

        public class GetCategoryByGuidQueryHandler : IRequestHandler<GetCategoryByGuidQuery, CategoryVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetCategoryByGuidQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                var primaryCategory = await _context.TblCategory
                    .Where(x => x.CategoryGuid == request.CategoryGuid && !x.CategoryIsDelete)
                    .SingleOrDefaultAsync(cancellationToken);

                if (primaryCategory != null)
                {
                    var category = new CategoryDto
                    {
                        CategoryDisplay = primaryCategory.CategoryDisplay,
                        CategoryOrder = primaryCategory.CategoryOrder,
                        SubCategories = await _context.TblCategory
                            .Where(x => x.CategoryCategoryId == primaryCategory.CategoryId && !x.CategoryIsDelete)
                            .OrderBy(x => x.CategoryOrder)
                            .ProjectTo<SubCategoryDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken)
                    };

                    if (category != null)
                    {
                        return new CategoryVm()
                        {
                            Message = "عملیات موفق آمیز",
                            Result = true,
                            Category = category
                        };
                    }
                }

                return new CategoryVm()
                {
                    Message = "یافت نشد",
                    Result = false,
                    Category = null
                };
            }
        }
    }
}

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

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class GetPrimaryCategoriesQuery : IRequest<PrimaryCategoriesVm>
    {
        public class GetPrimaryCategoriesQueryHandler : IRequestHandler<GetPrimaryCategoriesQuery, PrimaryCategoriesVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetPrimaryCategoriesQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PrimaryCategoriesVm> Handle(GetPrimaryCategoriesQuery request, CancellationToken cancellationToken)
            {
                var primaryCategories = await _context.TblCategory
                    .Where(x => x.CategoryCategoryGuid == null && !x.CategoryIsDelete)
                    .OrderBy(x => x.CategoryOrder)
                    .ProjectTo<PrimaryCategoryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (primaryCategories.Count > 0)
                {
                    return new PrimaryCategoriesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        Result = true,
                        PrimaryCategories = primaryCategories
                    };
                }

                return new PrimaryCategoriesVm()
                {
                    Message = "موردی یافت نشد",
                    Result = true,
                };
            }
        }
    }
}

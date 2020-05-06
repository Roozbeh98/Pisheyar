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
        public Guid? CategoryGuid { get; set; }

        public class GetPrimaryCategoriesQueryHandler : IRequestHandler<GetPrimaryCategoriesQuery, PrimaryCategoriesVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetPrimaryCategoriesQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<PrimaryCategoriesVm> Handle(GetPrimaryCategoriesQuery request, CancellationToken cancellationToken)
            {
                int? categoryId = null;

                if (request.CategoryGuid.HasValue)
                {
                    Category category = await _context.Category
                        .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid, cancellationToken);

                    if (category == null) return new PrimaryCategoriesVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        State = (int)GetPrimaryCategoriesState.CategoryNotFound
                    };

                    categoryId = category.CategoryId;
                }

                List<PrimaryCategoryDto> primaryCategories = await _context.Category
                    .Where(x => x.ParentCategoryId == categoryId && !x.IsDelete)
                    .OrderBy(x => x.Sort)
                    .ProjectTo<PrimaryCategoryDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (primaryCategories.Count <= 0) return new PrimaryCategoriesVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetPrimaryCategoriesState.NotFound,
                };

                return new PrimaryCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPrimaryCategoriesState.Success,
                    PrimaryCategories = primaryCategories
                };
            }
        }
    }
}

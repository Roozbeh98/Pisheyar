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

namespace Pisheyar.Application.Categories.Queries.SearchCategoriesByCity
{
    public class SearchCategoriesByCityQuery : IRequest<List<string>>
    {
        public Guid CityGuid { get; set; }

        public class SearchCategoriesByCityQueryHandler : IRequestHandler<SearchCategoriesByCityQuery, List<string>>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public SearchCategoriesByCityQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<string>> Handle(SearchCategoriesByCityQuery request, CancellationToken cancellationToken)
            {
                List<string> categories = await _context.ContractorCategory
                    .Where(x => x.Contractor.City.CityGuid == request.CityGuid)
                    .Join(_context.Category, cc => cc.CategoryId, c => c.CategoryId, (cc, c) => new { cc, c })
                    .Select(x => x.c.DisplayName)
                    .ToListAsync(cancellationToken);

                return categories.Count > 0 ? categories : new List<string>();
            }
        }
    }
}

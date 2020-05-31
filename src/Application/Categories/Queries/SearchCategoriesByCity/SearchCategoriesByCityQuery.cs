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
    public class SearchCategoriesByCityQuery : IRequest<SearchCategoriesByCityVm>
    {
        public Guid CityGuid { get; set; }

        public string SearchInput { get; set; }

        public class SearchCategoriesByCityQueryHandler : IRequestHandler<SearchCategoriesByCityQuery, SearchCategoriesByCityVm>
        {
            private readonly IPisheyarContext _context;

            public SearchCategoriesByCityQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<SearchCategoriesByCityVm> Handle(SearchCategoriesByCityQuery request, CancellationToken cancellationToken)
            {
                List<SearchCategoriesByCityDto> categories = await (from cc in _context.ContractorCategory
                                                                    where cc.Contractor.City.CityGuid == request.CityGuid
                                                                    join c in _context.Category on cc.CategoryId equals c.CategoryId
                                                                    join ct in _context.CategoryTag on cc.CategoryId equals ct.CategoryId into jct
                                                                    from ct in jct.DefaultIfEmpty()
                                                                    where cc.Category.DisplayName.Contains(request.SearchInput) || ct.Tag.Name.Contains(request.SearchInput)
                                                                    select new SearchCategoriesByCityDto
                                                                    {
                                                                       CategoryGuid = c.CategoryGuid,
                                                                       DisplayName = c.DisplayName,
                                                                    }).Distinct()
                                                                    .ToListAsync(cancellationToken);

                if (categories.Count <= 0)
                    return new SearchCategoriesByCityVm
                    {
                        Message = "نتیجه ای یافت نشد",
                        State = (int)SearchCategoriesByCityState.NotFound,
                    };

                return new SearchCategoriesByCityVm
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SearchCategoriesByCityState.Success,
                    Count = categories.Count,
                    Categories = categories
                };
            }
        }
    }
}

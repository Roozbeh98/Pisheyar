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

namespace Pisheyar.Application.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<AllCategoriesVm>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, AllCategoriesVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetCategoriesQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            //private async Task<AllCategoriesVm> Test(List<TblCategory> categories, CancellationToken cancellationToken)
            //{
            //    foreach (var category in categories)
            //    {
            //        var q = await _context.TblCategory
            //            .Where(x => x.CategoryCategoryId == category.CategoryId && !x.CategoryIsDelete)
            //            .OrderBy(x => x.CategoryOrder)
            //            .ToListAsync(cancellationToken);


            //    }
            //}

            public List<int> GetTaskNames(TblCategory category, List<int> categories = null)
            {
                if (categories == null)
                    categories = new List<int>();

                categories.Add(category.CategoryId);

                foreach (var child in category.InverseCategoryCategory)
                    GetTaskNames(child, categories);

                return categories;
            }

            public async Task<AllCategoriesVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var parentGroups = _context.TblCategory.ToLookup(x => x.CategoryId, x => new AllCategoryDto
                {
                    CategoryId = x.CategoryId,
                    CategoryDisplay = x.CategoryDisplay,
                    CategoryOrder = x.CategoryOrder
                });

                // fix up children
                foreach (var item in parentGroups.SelectMany(x => x))
                {
                    item.SubCategories = parentGroups[item.CategoryId].ToList();
                }

                var c1 = _context.TblCategory
                    .AsEnumerable()
                    .Where(x => x.CategoryId == 2)
                    //.AsQueryable()
                    //.ProjectTo<AllCategoryDto>(_mapper.ConfigurationProvider)
                    //.Where(x => x.CategoryCategoryId == null && !x.CategoryIsDelete)
                    //.OrderBy(x => x.CategoryOrder)
                    //.ProjectTo<AllCategoryDto>(_mapper.ConfigurationProvider)
                    .ToList();

                var c2 = c1[0].InverseCategoryCategory.SelectMany(x => GetTaskNames(x)).ToList();
                

                //await Test(categories, cancellationToken);

                //List<List<TblCategory>> categories = new List<List<TblCategory>>();
                //object test = new
                //{
                //    items = c1.Select(item => new
                //    {
                //        name = item.CategoryDisplay,
                //        order = item.CategoryOrder
                //    })
                //};

                //var t = ((System.Collections.ArrayList)test)[0];

                //foreach (var a in c1)
                //{
                //    var q1 = await _context.TblCategory
                //        .Where(x => x.CategoryCategoryId == a.CategoryId && !x.CategoryIsDelete)
                //        .OrderBy(x => x.CategoryOrder)
                //        .ToListAsync(cancellationToken);

                //    foreach (var b in q1)
                //    {
                //        var q2 = await _context.TblCategory
                //            .Where(x => x.CategoryCategoryId == b.CategoryId && !x.CategoryIsDelete)
                //            .OrderBy(x => x.CategoryOrder)
                //            .ToListAsync(cancellationToken);

                //        foreach (var c in q2)
                //        {
                //            var q3 = await _context.TblCategory
                //                .Where(x => x.CategoryCategoryId == c.CategoryId && !x.CategoryIsDelete)
                //                .OrderBy(x => x.CategoryOrder)
                //                .ToListAsync(cancellationToken);


                //        }
                //    }

                //    //var category = new AllCategoryDto
                //    //{
                //    //    CategoryDisplay = mainCategory.CategoryDisplay,
                //    //    CategoryOrder = mainCategory.CategoryOrder,
                //    //    SubCategories = await _context.TblCategory
                //    //        .Where(x => x.CategoryCategoryId == mainCategory.CategoryId && !x.CategoryIsDelete)
                //    //        .OrderBy(x => x.CategoryOrder)
                //    //        .ProjectTo<AllSubCategoryDto>(_mapper.ConfigurationProvider)
                //    //        .ToListAsync(cancellationToken)
                //    //};

                //    //categories.Add(category);
                //}

                return new AllCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Categories = null
                };
            }
        }
    }
}

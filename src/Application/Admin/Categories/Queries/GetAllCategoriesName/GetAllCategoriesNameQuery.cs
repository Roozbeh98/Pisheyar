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

namespace Pisheyar.Application.Categories.Queries.GetAllCategoriesName
{
    public class GetAllCategoriesNameQuery : IRequest<AllCategoriesNameVm>
    {
        public class GetCategoriesQueryHandler : IRequestHandler<GetAllCategoriesNameQuery, AllCategoriesNameVm>
        {
            private readonly IPisheyarMagContext _context;

            public GetCategoriesQueryHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            //public async Task<List<AllCategoryNameDto>> GetCategoryTree(List<TblCategory> allCategories, Guid? parentGuid = null)
            //{
            //    var categories = new List<AllCategoryNameDto>();

            //    var children = allCategories
            //        .Where(x => x.CategoryCategoryGuid == parentGuid)
            //        .OrderBy(x => x.CategoryOrder)
            //        .ToList();

            //    foreach (var child in children)
            //    {
            //        AllCategoryNameDto category = new AllCategoryNameDto
            //        {
            //            Guid = child.CategoryGuid,
            //            Title = child.CategoryDisplay
            //        };

            //        category.Children = await GetCategoryChildren(allCategories, category);

            //        categories.Add(category);
            //    }

            //    return categories;
            //}

            //private async Task<List<AllCategoryNameDto>> GetCategoryChildren(List<TblCategory> allCategories, AllCategoryNameDto category)
            //{
            //    var subCategories = allCategories
            //        .Where(x => x.CategoryCategoryGuid == category.Guid)
            //        .OrderBy(x => x.CategoryOrder)
            //        .Select(x => new AllCategoryNameDto
            //        {
            //            Guid = x.CategoryGuid,
            //            Title = x.CategoryDisplay

            //        }).ToList();

            //    if (subCategories != null)
            //    {
            //        category.Children = subCategories;

            //        foreach (var item in category.Children)
            //        {
            //            item.Children = await GetCategoryChildren(allCategories, item);
            //        }
            //    }

            //    return category.Children;
            //}

            public async Task<AllCategoriesNameVm> Handle(GetAllCategoriesNameQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.TblCategory
                    .Where(x => !x.CategoryIsDelete)
                    .OrderBy(x => x.CategoryOrder)
                    .Select(x => new AllCategoryNameDto
                    {
                        Guid = x.CategoryGuid,
                        Title = x.CategoryDisplay

                    }).ToListAsync(cancellationToken);

                if (categories.Count > 0)
                {
                    return new AllCategoriesNameVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetAllCategoriesNameState.Success,
                        Categories = categories
                    };
                }

                return new AllCategoriesNameVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetAllCategoriesNameState.NotFound
                };
            }
        }
    }
}

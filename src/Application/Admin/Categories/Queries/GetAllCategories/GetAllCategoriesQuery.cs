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

            public GetCategoriesQueryHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<List<AllCategoryDto>> GetCategoryTree(List<TblCategory> allCategories, Guid? parentGuid = null)
            {
                var categories = new List<AllCategoryDto>();

                var children = allCategories
                    .Where(x => x.CategoryCategoryGuid == parentGuid)
                    .OrderBy(x => x.CategoryOrder)
                    .ToList();

                foreach (var child in children)
                {
                    AllCategoryDto category = new AllCategoryDto
                    {
                        Guid = child.CategoryGuid,
                        ParentGuid = child.CategoryCategoryGuid,
                        Title = child.CategoryDisplay,
                        Order = child.CategoryOrder
                    };

                    category.Children = await GetCategoryChildren(allCategories, category);

                    categories.Add(category);
                }

                return categories;
            }

            private async Task<List<AllCategoryDto>> GetCategoryChildren(List<TblCategory> allCategories, AllCategoryDto category)
            {
                var subCategories = allCategories
                    .Where(x => x.CategoryCategoryGuid == category.Guid)
                    .OrderBy(x => x.CategoryOrder)
                    .Select(x => new AllCategoryDto
                    {
                        Guid = x.CategoryGuid,
                        ParentGuid = x.CategoryCategoryGuid,
                        Title = x.CategoryDisplay,
                        Order = x.CategoryOrder

                    }).ToList();

                if (subCategories != null)
                {
                    category.Children = subCategories;

                    foreach (var item in category.Children)
                    {
                        item.Children = await GetCategoryChildren(allCategories, item);
                    }
                }

                return category.Children;
            }

            public async Task<AllCategoriesVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.TblCategory
                    .Where(x => !x.CategoryIsDelete)
                    .ToListAsync(cancellationToken);

                var categoryTree = await GetCategoryTree(categories);

                if (categoryTree.Count > 0)
                {
                    return new AllCategoriesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        Result = true,
                        Categories = categoryTree
                    };
                }

                return new AllCategoriesVm()
                {
                    Message = "موردی یافت نشد",
                    Result = true,
                };
            }
        }
    }
}

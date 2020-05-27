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
            private readonly IPisheyarContext _context;

            public GetCategoriesQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<List<AllCategoryDto>> GetCategoryTree(List<Category> allCategories, int? parentId = null)
            {
                var categories = new List<AllCategoryDto>();

                var children = allCategories
                    .Where(x => x.ParentCategoryId == parentId)
                    .OrderBy(x => x.Sort)
                    .ToList();

                foreach (var child in children)
                {
                    AllCategoryDto category = new AllCategoryDto
                    {
                        Guid = child.CategoryGuid,
                        //ParentId = child.ParentCategoryId,
                        Title = child.DisplayName,
                        //Order = child.Sort
                    };

                    category.Children = await GetCategoryChildren(allCategories, category);

                    categories.Add(category);
                }

                return categories;
            }

            private async Task<List<AllCategoryDto>> GetCategoryChildren(List<Category> allCategories, AllCategoryDto category)
            {
                var c = await _context.Category
                      .Where(x => x.CategoryGuid == category.Guid)
                      .SingleOrDefaultAsync();

                if (c != null)
                {
                    var subCategories = allCategories
                        .Where(x => x.ParentCategoryId == c.CategoryId)
                        .OrderBy(x => x.Sort)
                        .Select(x => new AllCategoryDto
                        {
                            Guid = x.CategoryGuid,
                            //ParentId = x.ParentCategoryId,
                            Title = x.DisplayName,
                            //Order = x.Sort

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

                return null;
            }

            public async Task<AllCategoriesVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync(cancellationToken);

                var categoryTree = await GetCategoryTree(categories);

                if (categoryTree.Count > 0)
                {
                    return new AllCategoriesVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetAllCategoriesState.Success,
                        Categories = categoryTree
                    };
                }

                return new AllCategoriesVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetAllCategoriesState.NotFound
                };
            }
        }
    }
}

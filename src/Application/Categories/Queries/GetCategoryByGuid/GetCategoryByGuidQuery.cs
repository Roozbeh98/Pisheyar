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
            private readonly IPisheyarContext _context;

            public GetCategoryByGuidQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<List<CategoryDto>> GetCategoryTree(List<Category> allCategories, Guid parentGuid)
            {
                var c = await _context.Category
                    .Where(x => x.CategoryGuid == parentGuid)
                    .SingleOrDefaultAsync();

                if (c != null)
                {
                    var categories = new List<CategoryDto>();

                    var children = allCategories
                        .Where(x => x.ParentCategoryId == c.CategoryId)
                        .OrderBy(x => x.Sort)
                        .ToList();

                    foreach (var child in children)
                    {
                        CategoryDto category = new CategoryDto
                        {
                            Guid = child.CategoryGuid,
                            ParentId = child.ParentCategoryId,
                            Title = child.DisplayName,
                            Order = child.Sort
                        };

                        category.Children = await GetCategoryChildren(allCategories, category);

                        categories.Add(category);
                    }

                    return categories;
                }

                return null;
            }

            private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> allCategories, CategoryDto category)
            {
                var c = await _context.Category
                      .Where(x => x.CategoryGuid == category.Guid)
                      .SingleOrDefaultAsync();

                if (c != null)
                {
                    var subCategories = allCategories
                    .Where(x => x.ParentCategoryId == c.CategoryId)
                    .OrderBy(x => x.Sort)
                    .Select(x => new CategoryDto
                    {
                        Guid = x.CategoryGuid,
                        ParentId = x.ParentCategoryId,
                        Title = x.DisplayName,
                        Order = x.Sort

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

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync(cancellationToken);

                var categoryTree = await GetCategoryTree(categories, request.CategoryGuid);

                if (categoryTree.Count > 0)
                {
                    return new CategoryVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)GetCategoryByGuidState.Success,
                        Categories = categoryTree
                    };
                }

                return new CategoryVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetCategoryByGuidState.NotFound
                };
            }
        }
    }
}

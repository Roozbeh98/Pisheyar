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

            public GetCategoryByGuidQueryHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<List<CategoryDto>> GetCategoryTree(List<TblCategory> allCategories, Guid parentGuid)
            {
                var categories = new List<CategoryDto>();

                var children = allCategories
                    .Where(x => x.CategoryCategoryGuid == parentGuid)
                    .OrderBy(x => x.CategoryOrder)
                    .ToList();

                foreach (var child in children)
                {
                    CategoryDto category = new CategoryDto
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

            private async Task<List<CategoryDto>> GetCategoryChildren(List<TblCategory> allCategories, CategoryDto category)
            {
                var subCategories = allCategories
                    .Where(x => x.CategoryCategoryGuid == category.Guid)
                    .OrderBy(x => x.CategoryOrder)
                    .Select(x => new CategoryDto
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

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                var categories = await _context.TblCategory
                    .Where(x => !x.CategoryIsDelete)
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

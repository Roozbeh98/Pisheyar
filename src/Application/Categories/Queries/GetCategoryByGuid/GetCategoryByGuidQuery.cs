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
using Pisheyar.Application.Common;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class GetCategoryByGuidQuery : IRequest<CategoryVm>
    {
        public Guid CategoryGuid { get; set; }

        public bool IncludeChildren { get; set; }

        public class GetCategoryByGuidQueryHandler : IRequestHandler<GetCategoryByGuidQuery, CategoryVm>
        {
            private readonly IPisheyarContext _context;

            public GetCategoryByGuidQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<CategoryDto> GetCategory(Guid parentGuid, bool includeChildren = false)
            {
                CategoryDto category = await _context.Category
                    .Where(x => x.CategoryGuid == parentGuid && !x.IsDelete)
                    .Select(x => new CategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryGuid = x.CategoryGuid,
                        Title = x.DisplayName,
                        Description = x.Description,
                        Abstract = x.Abstract,
                        Sort = x.Sort,
                        CoverDocument = x.CoverDocument.Path,
                        ActiveIconDocument = x.ActiveIconDocument.Path,
                        InactiveIconDocument = x.InactiveIconDocument.Path,
                        QuadMenuDocument = x.QuadMenuDocument.Path,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).SingleOrDefaultAsync();

                if (category == null) return category;

                if (includeChildren)
                {
                    List<Category> categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync();

                    if (categories.Count <= 0) return category;

                    category.Children = await GetCategoryChildren(categories, category);
                }

                return category;
            }

            private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> categories, CategoryDto category)
            {
                var subCategories = categories
                    .Where(x => x.ParentCategoryId == category.CategoryId && !x.IsDelete)
                    .OrderBy(x => x.Sort)
                    .Select(x => new CategoryDto
                    {
                        CategoryId = x.CategoryId,
                        CategoryGuid = x.CategoryGuid,
                        Title = x.DisplayName,
                        Description = x.Description,
                        Abstract = x.Abstract,
                        Sort = x.Sort,
                        CoverDocument = x.CoverDocument?.Path,
                        ActiveIconDocument = x.ActiveIconDocument?.Path,
                        InactiveIconDocument = x.InactiveIconDocument?.Path,
                        QuadMenuDocument = x.QuadMenuDocument?.Path,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).ToList();

                if (subCategories.Count <= 0) return null;

                category.Children = subCategories;

                foreach (CategoryDto subCategory in category.Children)
                {
                    subCategory.Children = await GetCategoryChildren(categories, subCategory);
                }

                return category.Children;
            }

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                CategoryDto category = await GetCategory(request.CategoryGuid, request.IncludeChildren);

                if (category == null) return new CategoryVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetCategoryByGuidState.NotFound
                };

                return new CategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetCategoryByGuidState.Success,
                    Category = category
                };
            }
        }
    }
}

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

            public async Task<List<AllCategoryDto>> GetCategoryTree(List<TblCategory> allCategories, int? parentId = null)
            {
                var categories = new List<AllCategoryDto>();

                var children = allCategories
                    .Where(x => x.CategoryCategoryId == parentId)
                    .ToList();

                foreach (var child in children)
                {
                    AllCategoryDto category = new AllCategoryDto
                    {
                        CategoryId = child.CategoryId,
                        ParentId = child.CategoryCategoryId,
                        CategoryDisplay = child.CategoryDisplay,
                        CategoryOrder = child.CategoryOrder
                    };

                    category.SubCategories = await GetCategoryChildren(allCategories, category);

                    categories.Add(category);
                }

                return categories;
            }

            private async Task<List<AllCategoryDto>> GetCategoryChildren(List<TblCategory> allCategories, AllCategoryDto category)
            {
                var subCategories = allCategories
                    .Where(b => b.CategoryCategoryId == category.CategoryId)
                    .Select(x => new AllCategoryDto
                    {
                        CategoryId = x.CategoryId,
                        ParentId = x.CategoryCategoryId,
                        CategoryDisplay = x.CategoryDisplay,
                        CategoryOrder = x.CategoryOrder

                    }).ToList();

                if (subCategories != null)
                {
                    category.SubCategories = subCategories;

                    foreach (var item in category.SubCategories)
                    {
                        item.SubCategories = await GetCategoryChildren(allCategories, item);
                    }
                }

                return category.SubCategories;
            }

            public async Task<AllCategoriesVm> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
            {
                var categories = _context.TblCategory.ToList();

                var categoryTree = await GetCategoryTree(categories);

                return new AllCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Categories = categoryTree
                };
            }
        }
    }
}

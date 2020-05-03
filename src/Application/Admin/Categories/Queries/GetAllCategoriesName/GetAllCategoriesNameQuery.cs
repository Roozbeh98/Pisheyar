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
            private readonly IPisheyarContext _context;
            
            public GetCategoriesQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<List<AllCategoriesNameDto>> GetCategoryTree(int? parentId = null)
            {
                List<AllCategoriesNameDto> absoluteCategories = new List<AllCategoriesNameDto>();

                List<Category> categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync();

                if (categories.Count <= 0) return absoluteCategories;

                List<Category> subCategories = categories
                    .Where(x => x.ParentCategoryId == parentId)
                    .OrderBy(x => x.Sort)
                    .ToList();

                foreach (Category subCategory in subCategories)
                {
                    List<Tuple<int, int?>> previousCategories = new List<Tuple<int, int?>>();

                    AllCategoryNameAbstractDto category = new AllCategoryNameAbstractDto
                    {
                        Id = subCategory.CategoryId,
                        Guid = subCategory.CategoryGuid,
                        ParentId = subCategory.ParentCategoryId,
                        Title = subCategory.DisplayName,
                        Sort = subCategory.Sort
                    };

                    absoluteCategories.Add(new AllCategoriesNameDto() { Guid = category.Guid, Name = category.Title});
                    previousCategories.Add(new Tuple<int, int?>(category.Id, category.ParentId));

                    category.SubCategories = await GetCategoryChildren(categories, category, previousCategories, absoluteCategories);
                }

                return absoluteCategories;
            }

            private static async Task<List<AllCategoryNameAbstractDto>> GetCategoryChildren(List<Category> categories,
                AllCategoryNameAbstractDto category,
                List<Tuple<int, int?>> previousCategories,
                List<AllCategoriesNameDto> absoluteCategories)
            {
                List<AllCategoryNameAbstractDto> subCategories = categories
                    .Where(x => x.ParentCategoryId == category.Id)
                    .OrderBy(x => x.Sort)
                    .Select(x => new AllCategoryNameAbstractDto
                    {
                        Id = x.CategoryId,
                        Guid = x.CategoryGuid,
                        ParentId = x.ParentCategoryId,
                        Title = x.DisplayName,
                        Sort = x.Sort

                    }).ToList();

                if (subCategories.Count <= 0) return null;

                category.SubCategories = subCategories;

                foreach (AllCategoryNameAbstractDto subCategory in category.SubCategories)
                {
                    if (subCategory.ParentId == previousCategories[^1].Item1)
                    {
                        absoluteCategories.Add(new AllCategoriesNameDto() { Guid = subCategory.Guid, Name = absoluteCategories[^1].Name + $", {subCategory.Title}" });
                    }
                    else
                    {
                        string name = string.Copy(absoluteCategories[^1].Name);
                        int counter = 0;

                        do
                        {
                            counter++;

                        } while (subCategory.ParentId != previousCategories[^counter].Item2);

                        for (int i = 0; i < counter; i++)
                        {
                            int startIndex = name.LastIndexOf(",", StringComparison.Ordinal);
                            int length = name.Length;
                            name = name.Remove(startIndex, length - startIndex);
                        }

                        absoluteCategories.Add(new AllCategoriesNameDto() { Guid = subCategory.Guid, Name = name + $", {subCategory.Title}" });

                        int index = previousCategories.FindIndex(x => x.Item2 == subCategory.ParentId);
                        while (previousCategories.Count >= index + 1)
                        {
                            previousCategories.RemoveAt(index);
                        }
                    }

                    previousCategories.Add(new Tuple<int, int?>(subCategory.Id, subCategory.ParentId));

                    subCategory.SubCategories = await GetCategoryChildren(categories, subCategory, previousCategories, absoluteCategories);
                }

                return category.SubCategories;
            }

            public async Task<AllCategoriesNameVm> Handle(GetAllCategoriesNameQuery request, CancellationToken cancellationToken)
            {
                List<AllCategoriesNameDto> categoryTree = await GetCategoryTree();

                if (categoryTree.Count <= 0) return new AllCategoriesNameVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)GetAllCategoriesNameState.NotFound
                };

                return new AllCategoriesNameVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllCategoriesNameState.Success,
                    Categories = categoryTree
                };
            }
        }
    }
}

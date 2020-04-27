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
            private bool b = false;

            public GetCategoriesQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<List<string>> GetCategoryTree(List<Category> allCategories, int? parentId = null)
            {
                var test = new List<string>();

                var categories = new List<AllCategoryNameDto>();

                var children = allCategories
                    .Where(x => x.ParentCategoryId == parentId)
                    .OrderBy(x => x.Sort)
                    .ToList();

                foreach (var child in children)
                {
                    AllCategoryNameDto category = new AllCategoryNameDto
                    {
                        Guid = child.CategoryGuid,
                        ParentId = child.ParentCategoryId,
                        Title = child.DisplayName,
                        Order = child.Sort
                    };

                    b = false;
                    test.Add(category.Title);

                    category.Children = await GetCategoryChildren(allCategories, category, test);

                    categories.Add(category);
                }

                return test/*.OrderBy(x => x).ToList()*/;
            }

            private async Task<List<AllCategoryNameDto>> GetCategoryChildren(List<Category> allCategories, AllCategoryNameDto category, List<string> test)
            {
                var c = await _context.Category
                    .Where(x => x.CategoryGuid == category.Guid)
                    .SingleOrDefaultAsync();

                var subCategories = allCategories
                    .Where(x => x.ParentCategoryId == c.ParentCategoryId)
                    .OrderBy(x => x.Sort)
                    .Select(x => new AllCategoryNameDto
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
                        string t;

                        if (!b && item.Equals(category.Children.Last()))
                        {
                            string result = test[^1] + ", " + item.Title;
                            test.Add(result);

                            b = true;
                        }
                        else
                        {
                            if (b)
                            {
                                t = test[^1].Remove(test[^1].LastIndexOf(","));
                                if (t.Contains(","))
                                {
                                    t = t.Remove(t.LastIndexOf(","));
                                }

                                string result = t + ", " + item.Title;
                                test.Add(result);

                                b = false;
                            }
                            else
                            {
                                string result = test[^1] + ", " + item.Title;
                                test.Add(result);
                            }
                        }

                        item.Children = await GetCategoryChildren(allCategories, item, test);
                    }
                }

                return category.Children;
            }

            public async Task<AllCategoriesNameVm> Handle(GetAllCategoriesNameQuery request, CancellationToken cancellationToken)
            {
                //var categories = await _context.TblCategory
                //    .Where(x => !x.CategoryIsDelete)
                //    .ToListAsync(cancellationToken);

                //var categoryTree = await GetCategoryTree(categories);

                //if (categoryTree.Count > 0)
                //{
                //    return new AllCategoriesNameVm()
                //    {
                //        Message = "عملیات موفق آمیز",
                //        State = (int)GetAllCategoriesNameState.Success,
                //        Categories = categoryTree
                //    };
                //}

                var categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .OrderBy(x => x.Sort)
                    .Select(x => new AllCategoryNameDto
                    {
                        Guid = x.CategoryGuid,
                        Title = x.DisplayName

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

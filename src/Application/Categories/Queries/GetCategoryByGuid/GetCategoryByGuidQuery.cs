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
using Pisheyar.Application.Common.UploadHelper.Filepond;

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

            public async Task<CategoryDtoResult> GetCategory(Guid parentGuid, bool includeChildren = false)
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
                        CoverDocument = new FilepondDto
                        {
                            Source = x.CoverDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.CoverDocument.Name,
                                    Size = x.CoverDocument.Size.ToString(),
                                    Type = x.CoverDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.CoverDocument.Path
                                }
                            }
                        },
                        ActiveIconDocument = new FilepondDto
                        {
                            Source = x.ActiveIconDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.ActiveIconDocument.Name,
                                    Size = x.ActiveIconDocument.Size.ToString(),
                                    Type = x.ActiveIconDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.ActiveIconDocument.Path
                                }
                            }
                        },
                        InactiveIconDocument = new FilepondDto
                        {
                            Source = x.InactiveIconDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.InactiveIconDocument.Name,
                                    Size = x.InactiveIconDocument.Size.ToString(),
                                    Type = x.InactiveIconDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.InactiveIconDocument.Path
                                }
                            }
                        },
                        QuadMenuDocument = new FilepondDto
                        {
                            Source = x.QuadMenuDocument.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.QuadMenuDocument.Name,
                                    Size = x.QuadMenuDocument.Size.ToString(),
                                    Type = x.QuadMenuDocument.TypeCode.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.QuadMenuDocument.Path
                                }
                            }
                        },
                        Tags = x.CategoryTag.OrderBy(x => x.Tag.Name)
                            .Select(x => new GetCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetCategoryTagNameDto>,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).SingleOrDefaultAsync();

                if (category == null)
                    return null;

                if (includeChildren)
                {
                    List<Category> categories = await _context.Category
                       .Where(x => !x.IsDelete)
                       .ToListAsync();

                    if (categories.Count <= 0)
                        return null;

                    category.Children = await GetCategoryChildren(categories, category);
                }
                else
                    category.Children = new List<CategoryDto>();

                return new CategoryDtoResult()
                {
                    CategoryGuid = category.CategoryGuid,
                    Title = category.Title,
                    Abstract = category.Abstract,
                    Description = category.Description,
                    Sort = category.Sort,
                    CoverDocument = category.CoverDocument,
                    ActiveIconDocument = category.ActiveIconDocument,
                    InactiveIconDocument = category.InactiveIconDocument,
                    QuadMenuDocument = category.QuadMenuDocument,
                    Tags = category.Tags,
                    IsActive = category.IsActive,
                    ModifiedDate = category.ModifiedDate,
                    Children = category.Children
                };
            }

            private async Task<List<CategoryDto>> GetCategoryChildren(List<Category> categories, CategoryDto category)
            {
                List<CategoryDto> subCategories = categories
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
                        CoverDocument = new FilepondDto
                        {
                            Source = x.CoverDocument?.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.CoverDocument?.Name,
                                    Size = x.CoverDocument?.Size.ToString(),
                                    Type = x.CoverDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.CoverDocument?.Path
                                }
                            }
                        },
                        ActiveIconDocument = new FilepondDto
                        {
                            Source = x.ActiveIconDocument?.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.ActiveIconDocument?.Name,
                                    Size = x.ActiveIconDocument?.Size.ToString(),
                                    Type = x.ActiveIconDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.ActiveIconDocument?.Path
                                }
                            }
                        },
                        InactiveIconDocument = new FilepondDto
                        {
                            Source = x.InactiveIconDocument?.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.InactiveIconDocument?.Name,
                                    Size = x.InactiveIconDocument?.Size.ToString(),
                                    Type = x.InactiveIconDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.InactiveIconDocument?.Path
                                }
                            }
                        },
                        QuadMenuDocument = new FilepondDto
                        {
                            Source = x.QuadMenuDocument?.Path,
                            Options = new FilepondOptions
                            {
                                Type = "local",
                                Files = new FilepondFile
                                {
                                    Name = x.QuadMenuDocument?.Name,
                                    Size = x.QuadMenuDocument?.Size.ToString(),
                                    Type = x.QuadMenuDocument?.TypeCode?.Name
                                },
                                Metadata = new FilepondMetadata
                                {
                                    Poster = x.QuadMenuDocument?.Path
                                }
                            }
                        },
                        Tags = x.CategoryTag.OrderBy(x => x.Tag.Name)
                            .Select(x => new GetCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetCategoryTagNameDto> ?? null,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).ToList();

                if (subCategories.Count <= 0) return new List<CategoryDto>();

                category.Children = subCategories;

                foreach (CategoryDto subCategory in category.Children)
                    subCategory.Children = await GetCategoryChildren(categories, subCategory);

                return category.Children;
            }

            public async Task<CategoryVm> Handle(GetCategoryByGuidQuery request, CancellationToken cancellationToken)
            {
                CategoryDtoResult category = await GetCategory(request.CategoryGuid, request.IncludeChildren);

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

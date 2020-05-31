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
using Pisheyar.Application.Common.UploadHelper.Filepond;
using Pisheyar.Application.Common;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class GetPrimaryCategoriesQuery : IRequest<PrimaryCategoriesVm>
    {
        public Guid? CategoryGuid { get; set; }

        public class GetPrimaryCategoriesQueryHandler : IRequestHandler<GetPrimaryCategoriesQuery, PrimaryCategoriesVm>
        {
            private readonly IPisheyarContext _context;

            public GetPrimaryCategoriesQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<PrimaryCategoriesVm> Handle(GetPrimaryCategoriesQuery request, CancellationToken cancellationToken)
            {
                IQueryable<Category> categories = _context.Category
                    .Where(x => !x.IsDelete);

                if (request.CategoryGuid.HasValue)
                {
                    Category category = await _context.Category
                        .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid && !x.IsDelete, cancellationToken);

                    if (category == null) return new PrimaryCategoriesVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        State = (int)GetPrimaryCategoriesState.CategoryNotFound
                    };

                    categories = categories.Where(x => x.ParentCategoryId == category.CategoryId);
                }
                else
                    categories = categories.Where(x => x.ParentCategoryId == null);

                List<PrimaryCategoryDto> primaryCategories = await categories.OrderBy(x => x.Sort)
                    .Select(x => new PrimaryCategoryDto
                    {
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
                            Source = x.CoverDocument.Path,
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
                            Source = x.CoverDocument.Path,
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
                            Source = x.CoverDocument.Path,
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
                            .Select(x => new GetPrimaryCategoryTagNameDto
                            {
                                Guid = x.Tag.TagGuid,
                                Name = x.Tag.Name

                            }) as List<GetPrimaryCategoryTagNameDto>,
                        IsActive = x.IsActive,
                        ModifiedDate = PersianDateExtensionMethods.ToPeString(x.ModifiedDate, "yyyy/MM/dd HH:mm")

                    }).ToListAsync(cancellationToken);

                if (primaryCategories.Count <= 0) return new PrimaryCategoriesVm()
                {
                    Message = "دسته بندی ای یافت نشد",
                    State = (int)GetPrimaryCategoriesState.NotAnyCategoriesFound,
                };

                return new PrimaryCategoriesVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPrimaryCategoriesState.Success,
                    PrimaryCategories = primaryCategories
                };
            }
        }
    }
}

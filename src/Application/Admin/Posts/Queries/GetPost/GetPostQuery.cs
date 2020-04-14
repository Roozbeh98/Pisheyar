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

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostQuery : IRequest<GetPostVm>
    {
        public Guid Guid { get; set; }

        public class GetPostQueryHandler : IRequestHandler<GetPostQuery, GetPostVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly IMapper _mapper;

            public GetPostQueryHandler(IPisheyarMagContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            //public async Task<List<GetPostCategoryDto>> GetCategoryTree(List<TblCategory> allCategories, Guid parentGuid)
            //{
            //    var categories = new List<GetPostCategoryDto>();

            //    var children = allCategories
            //        .Where(x => x.CategoryCategoryGuid == parentGuid)
            //        .OrderBy(x => x.CategoryOrder)
            //        .ToList();

            //    foreach (var child in children)
            //    {
            //        GetPostCategoryDto category = new GetPostCategoryDto
            //        {
            //            Guid = child.CategoryGuid,
            //            ParentGuid = child.CategoryCategoryGuid,
            //            Title = child.CategoryDisplay,
            //            Order = child.CategoryOrder
            //        };

            //        category.Children = await GetCategoryChildren(allCategories, category);

            //        categories.Add(category);
            //    }

            //    return categories;
            //}

            //private async Task<List<GetPostCategoryDto>> GetCategoryChildren(List<TblCategory> allCategories, GetPostCategoryDto category)
            //{
            //    var subCategories = allCategories
            //        .Where(x => x.CategoryCategoryGuid == category.Guid)
            //        .OrderBy(x => x.CategoryOrder)
            //        .Select(x => new GetPostCategoryDto
            //        {
            //            Guid = x.CategoryGuid,
            //            ParentGuid = x.CategoryCategoryGuid,
            //            Title = x.CategoryDisplay,
            //            Order = x.CategoryOrder

            //        }).ToList();

            //    if (subCategories != null)
            //    {
            //        category.Children = subCategories;

            //        foreach (var item in category.Children)
            //        {
            //            item.Children = await GetCategoryChildren(allCategories, item);
            //        }
            //    }

            //    return category.Children;
            //}

            public async Task<GetPostVm> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.TblPost
                    .Where(x => x.PostGuid == request.Guid && !x.PostIsDelete)
                    .ProjectTo<GetPostDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

                if (post == null)
                {
                    return new GetPostVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        State = (int)GetPostState.PostNotFound
                    };
                }

                var postCategories = await _context.TblPostCategory
                    .Where(x => x.PcPostGuid == request.Guid)
                    .OrderBy(x => x.PcCategoryGu.CategoryDisplay)
                    .Select(x => x.PcCategoryGu.CategoryDisplay)
                    .ToListAsync(cancellationToken);

                if (postCategories.Count > 0)
                {
                    post.Categories = postCategories;
                }

                //var postCategories = await _context.TblPostCategory
                //    .Where(x => x.PcPostGuid == request.Guid)
                //    .ToListAsync(cancellationToken);

                //foreach (var postCategory in postCategories)
                //{
                //    var categories = await _context.TblCategory
                //        .Where(x => !x.CategoryIsDelete)
                //        .ToListAsync(cancellationToken);

                //    var categoryTree = await GetCategoryTree(categories, postCategory.PcCategoryGuid);

                //    if (categoryTree.Count > 0)
                //    {
                //        post.Categories.Add(categoryTree);
                //    }
                //}

                return new GetPostVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetPostState.Success,
                    Post = post
                };
            }
        }
    }
}

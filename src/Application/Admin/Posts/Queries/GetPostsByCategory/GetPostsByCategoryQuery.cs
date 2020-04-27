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

namespace Pisheyar.Application.Posts.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryQuery : IRequest<GetPostsByCategoryVm>
    {
        public Guid CategoryGuid { get; set; }

        public int Page { get; set; }

        public class GetPostsByCategoryQueryHandler : IRequestHandler<GetPostsByCategoryQuery, GetPostsByCategoryVm>
        {
            private readonly IPisheyarContext _context;

            public GetPostsByCategoryQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<GetPostsByCategoryVm> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _context.Category
                    .Where(x => x.CategoryGuid == request.CategoryGuid)
                    .SingleOrDefaultAsync(cancellationToken);

                if (category == null)
                {
                    return new GetPostsByCategoryVm()
                    {
                        Message = "دسته بندی مورد نظر یافت نشد",
                        Result = false
                    };
                }

                var posts = await (from pc in _context.PostCategory
                                   where pc.CategoryId == category.CategoryId
                                   join p in _context.Post on pc.PostId equals p.PostId
                                   orderby p.ModifiedDate descending
                                   select new GetPostsByCategoryDto
                                   {
                                       PostGuid = p.PostGuid,
                                       UserFullName = p.User.FirstName + " " + p.User.LastName,
                                       DocumentFileName = p.Document.Name,
                                       PostViewCount = p.ViewCount,
                                       PostLikeCount = p.LikeCount,
                                       PostTitle = p.Title,
                                       PostAbstract = p.Abstract,
                                       PostDescription = p.Description,
                                       PostModifyDate = p.ModifiedDate,
                                       PostIsShow = p.IsShow

                                   }).Skip(12 * (request.Page - 1))
                                   .Take(12)
                                   .ToListAsync(cancellationToken);

                return new GetPostsByCategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    Result = true,
                    Posts = posts
                };
            }
        }
    }
}

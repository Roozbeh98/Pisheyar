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
            private readonly IPisheyarMagContext _context;

            public GetPostsByCategoryQueryHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<GetPostsByCategoryVm> Handle(GetPostsByCategoryQuery request, CancellationToken cancellationToken)
            {
                var posts = await (from pc in _context.TblPostCategory
                                   where pc.PcCategoryGuid == request.CategoryGuid
                                   join p in _context.TblPost on pc.PcPostGuid equals p.PostGuid
                                   orderby p.PostModifyDate descending
                                   select new GetPostsByCategoryDto
                                   {
                                       PostGuid = p.PostGuid,
                                       UserFullName = p.PostUser.UserName + " " + p.PostUser.UserFamily,
                                       DocumentFileName = p.PostDocument.DocumentFileName,
                                       PostViewCount = p.PostViewCount,
                                       PostLikeCount = p.PostLikeCount,
                                       PostTitle = p.PostTitle,
                                       PostAbstract = p.PostAbstract,
                                       PostDescription = p.PostDescription,
                                       PostCreateDate = p.PostCreateDate,
                                       PostModifyDate = p.PostModifyDate,
                                       PostIsShow = p.PostIsShow

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

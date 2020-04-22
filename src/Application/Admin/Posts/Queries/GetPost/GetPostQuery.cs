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

                var postCategory = await _context.TblPostCategory
                    .Where(x => x.PcPostGuid == request.Guid)
                    .OrderBy(x => x.PcCategoryGu.CategoryDisplay)
                    .Select(x => new GetPostCategoryNameDto
                    {
                        Guid = x.PcCategoryGu.CategoryGuid,
                        Title = x.PcCategoryGu.CategoryDisplay

                    }).FirstOrDefaultAsync(cancellationToken);

                if (postCategory != null)
                {
                    post.Category = postCategory;
                }

                var postTags = await _context.TblPostTag
                    .Where(x => x.PtPostGuid == request.Guid)
                    .OrderBy(x => x.PtTag.TagName)
                    .Select(x => new GetPostTagNameDto
                    {
                        Guid = x.PtTag.TagGuid,
                        Name = x.PtTag.TagName

                    }).ToListAsync(cancellationToken);

                if (postTags.Count > 0)
                {
                    post.Tags = postTags;
                }

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

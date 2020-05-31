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
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetPostQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetPostVm> Handle(GetPostQuery request, CancellationToken cancellationToken)
            {
                var post = await _context.Post
                    .Where(x => x.PostGuid == request.Guid && !x.IsDelete)
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

                var p = await _context.Post
                    .Where(x => x.PostGuid == request.Guid)
                    .SingleOrDefaultAsync();

                if (p == null)
                {
                    return new GetPostVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        State = (int)GetPostState.PostNotFound
                    };
                }

                var postCategory = await _context.PostCategory
                    .Where(x => x.PostId == p.PostId)
                    .OrderBy(x => x.Category.DisplayName)
                    .Select(x => new GetPostCategoryNameDto
                    {
                        Guid = x.Category.CategoryGuid,
                        Title = x.Category.DisplayName

                    }).FirstOrDefaultAsync(cancellationToken);

                if (postCategory != null)
                {
                    post.Category = postCategory;
                }

                var postTags = await _context.PostTag
                    .Where(x => x.PostId == p.PostId)
                    .OrderBy(x => x.Tag.Name)
                    .Select(x => new GetPostTagNameDto
                    {
                        Guid = x.Tag.TagGuid,
                        Name = x.Tag.Name

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

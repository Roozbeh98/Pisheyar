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

namespace Pisheyar.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostsQuery : IRequest<GetAllPostVm>
    {
        public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetAllPostsQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetAllPostVm> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await _context.Post
                    .Where(x => !x.IsDelete)
                    .OrderByDescending(x => x.ModifiedDate)
                    .ProjectTo<GetAllPostDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

                if (posts.Count == 0)
                {
                    return new GetAllPostVm()
                    {
                        Message = "پستی یافت نشد",
                        State = (int)GetAllPostsState.NoPosts
                    };
                }

                foreach (var post in posts)
                {
                    var p = await _context.Post
                        .Where(x => x.PostGuid == post.PostGuid)
                        .SingleOrDefaultAsync();

                    if (p == null)
                    {
                        continue;
                    }

                    var postCategory = await _context.PostCategory
                    .Where(x => x.PostId == p.PostId)
                    .OrderBy(x => x.Category.DisplayName)
                    .Select(x => new GetAllPostCategoryNameDto
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
                        .Select(x => new GetAllPostTagNameDto
                        {
                            Guid = x.Tag.TagGuid,
                            Name = x.Tag.Name

                        }).ToListAsync(cancellationToken);

                    if (postTags.Count > 0)
                    {
                        post.Tags = postTags;
                    }
                }

                return new GetAllPostVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetAllPostsState.Success,
                    Posts = posts
                };
            }
        }
    }
}

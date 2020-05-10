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

namespace Pisheyar.Application.Posts.Queries.GetWeeklyMostViewedPosts
{
    public class GetWeeklyMostViewedPostsQuery : IRequest<GetWeeklyMostViewedPostsVm>
    {
        public class GetWeeklyMostViewedPostsQueryHandler : IRequestHandler<GetWeeklyMostViewedPostsQuery, GetWeeklyMostViewedPostsVm>
        {
            private readonly IPisheyarContext _context;
            private readonly IMapper _mapper;

            public GetWeeklyMostViewedPostsQueryHandler(IPisheyarContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetWeeklyMostViewedPostsVm> Handle(GetWeeklyMostViewedPostsQuery request, CancellationToken cancellationToken)
            {
                var posts = await _context.Post
                    .Where(x => !x.IsDelete)
                    .OrderByDescending(x => x.ViewCount)
                    .ProjectTo<GetWeeklyMostViewedPostsDto>(_mapper.ConfigurationProvider)
                    .Take(5)
                    .ToListAsync(cancellationToken);

                if (posts.Count == 0)
                {
                    return new GetWeeklyMostViewedPostsVm()
                    {
                        Message = "پستی یافت نشد",
                        State = (int)GetIndexPostsState.NoPosts
                    };
                }

                foreach (var post in posts)
                {
                    var p = await _context.Post
                        .Where(x => x.PostGuid == post.PostGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    if (p == null)
                    {
                        continue;
                    }

                    var postCategory = await _context.PostCategory
                        .Where(x => x.PostId == p.PostId)
                        .OrderBy(x => x.Category.DisplayName)
                        .Select(x => new GetWeeklyMostViewedPostsCategoryNameDto
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
                        .Select(x => new GetWeeklyMostViewedPostsTagNameDto
                        {
                            Guid = x.Tag.TagGuid,
                            Name = x.Tag.Name

                        }).ToListAsync(cancellationToken);

                    if (postTags.Count > 0)
                    {
                        post.Tags = postTags;
                    }
                }

                return new GetWeeklyMostViewedPostsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)GetIndexPostsState.Success,
                    Posts = posts
                };
            }
        }
    }
}

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

namespace Pisheyar.Application.Posts.Commands.CreatePost
{
    public class CreatePostCommand : IRequest<CreatePostCommandVm>
    {
        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public bool IsShow { get; set; }

        public string DocumentGuid { get; set; }

        public Guid[] Categories { get; set; }

        public string[] Tags { get; set; }

        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandVm>
        {
            private readonly IPisheyarContext _context;
            private readonly ICurrentUserService _currentUserService;

            public CreatePostCommandHandler(IPisheyarContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<CreatePostCommandVm> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var currentUser = await _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new CreatePostCommandVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)CreatePostState.UserNotFound
                    };
                }

                var document = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.DocumentGuid), cancellationToken);

                if (document == null)
                {
                    return new CreatePostCommandVm()
                    {
                        Message = "تصویر مورد نظر یافت نشد",
                        State = (int)CreatePostState.DocumentNotFound
                    };
                }

                var post = new Post
                {
                    UserId = currentUser.UserId,
                    Title = request.Title,
                    Abstract = request.Abstract,
                    Description = request.Description,
                    IsShow = request.IsShow,
                    DocumentId = document.DocumentId
                };

                foreach (var categoryGuid in request.Categories)
                {
                    var category = await _context.Category
                        .Where(x => x.CategoryGuid == categoryGuid)
                        .SingleOrDefaultAsync(cancellationToken);

                    var postCategory = new PostCategory()
                    {
                        Post = post,
                        CategoryId = category.CategoryId
                    };

                    _context.PostCategory.Add(postCategory);
                }

                PostTag postTag;

                foreach (var tag in request.Tags)
                {
                    Guid.TryParse(tag, out Guid guid);

                    if (guid == Guid.Empty)
                    {
                        var newTag = new Tag()
                        {
                            Name = tag
                        };

                        _context.Tag.Add(newTag);

                        postTag = new PostTag()
                        {
                            Post = post
                        };

                        postTag.Tag = newTag;
                    }
                    else
                    {
                        var t = await _context.Tag
                            .Where(x => x.TagGuid == Guid.Parse(tag))
                            .SingleOrDefaultAsync(cancellationToken);

                        postTag = new PostTag()
                        {
                            Post = post,
                            TagId = t.TagId
                        };
                    }
                    
                    _context.PostTag.Add(postTag);
                }

                _context.Post.Add(post);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreatePostCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)CreatePostState.Success
                };
            }
        }
    }
}

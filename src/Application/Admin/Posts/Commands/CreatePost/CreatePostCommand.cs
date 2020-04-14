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
            private readonly IPisheyarMagContext _context;
            private readonly ICurrentUserService _currentUserService;

            public CreatePostCommandHandler(IPisheyarMagContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<CreatePostCommandVm> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                var document = _context.TblDocument
                    .AnyAsync(x => x.DocumentGuid == Guid.Parse(request.DocumentGuid), cancellationToken);

                if (!document.Result)
                {
                    return new CreatePostCommandVm()
                    {
                        Message = "تصویر مورد نظر یافت نشد",
                        State = (int)CreatePostState.DocumentNotFound
                    };
                }

                var currentUser = await _context.TblUser
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

                var post = new TblPost
                {
                    PostUserId = currentUser.UserId,
                    PostTitle = request.Title,
                    PostAbstract = request.Abstract,
                    PostDescription = request.Description,
                    PostIsShow = request.IsShow,
                    PostDocumentGuid = Guid.Parse(request.DocumentGuid)
                };

                foreach (var categoryGuid in request.Categories)
                {
                    var postCategory = new TblPostCategory()
                    {
                        PcPost = post,
                        PcCategoryGuid = categoryGuid
                    };

                    _context.TblPostCategory.Add(postCategory);
                }

                TblPostTag postTag;

                foreach (var tag in request.Tags)
                {
                    Guid.TryParse(tag, out Guid guid);

                    if (guid == Guid.Empty)
                    {
                        var newTag = new TblTag()
                        {
                            TagName = tag
                        };

                        _context.TblTag.Add(newTag);

                        postTag = new TblPostTag()
                        {
                            PtPost = post
                        };

                        postTag.PtTag = newTag;
                    }
                    else
                    {
                        postTag = new TblPostTag()
                        {
                            PtPost = post,
                            PtTagGuid = Guid.Parse(tag)
                        };
                    }
                    
                    _context.TblPostTag.Add(postTag);
                }

                _context.TblPost.Add(post);

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

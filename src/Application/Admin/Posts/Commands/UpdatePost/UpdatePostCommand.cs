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
using System.IO;

namespace Pisheyar.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostCommandVm>
    {
        public UpdatePostCommandDto Command { get; set; }

        public string WebRootPath { get; set; }

        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandVm>
        {
            private readonly IPisheyarMagContext _context;
            private readonly ICurrentUserService _currentUserService;

            public UpdatePostCommandHandler(IPisheyarMagContext context, ICurrentUserService currentUserService)
            {
                _context = context;
                _currentUserService = currentUserService;
            }

            public async Task<UpdatePostCommandVm> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var post = await _context.TblPost
                    .SingleOrDefaultAsync(x => x.PostGuid == request.Command.PostGuid && !x.PostIsDelete);

                if (post == null)
                {
                    return new UpdatePostCommandVm()
                    {
                        Message = "پست مورد نظر یافت نشد",
                        State = (int)UpdatePostState.PostNotFound
                    };
                }

                var currentUser = await _context.TblUser
                    .Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier))
                    .SingleOrDefaultAsync(cancellationToken);

                if (currentUser == null)
                {
                    return new UpdatePostCommandVm()
                    {
                        Message = "کاربر مورد نظر یافت نشد",
                        State = (int)UpdatePostState.UserNotFound
                    };
                }

                if (!string.IsNullOrEmpty(request.Command.DocumentGuid))
                {
                    var document = await _context.TblDocument
                        .AnyAsync(x => x.DocumentGuid == Guid.Parse(request.Command.DocumentGuid), cancellationToken);

                    if (!document)
                    {
                        return new UpdatePostCommandVm()
                        {
                            Message = "تصویر مورد نظر یافت نشد",
                            State = (int)UpdatePostState.DocumentNotFound
                        };
                    }

                    var oldDocument = await _context.TblDocument
                        .FirstOrDefaultAsync(x => x.DocumentGuid == post.PostDocumentGuid, cancellationToken);

                    post.PostDocumentGuid = Guid.Parse(request.Command.DocumentGuid);

                    if (oldDocument != null)
                    {
                        var uploadsIndex = oldDocument.DocumentPath.IndexOf("Uploads");
                        var documentPath = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, oldDocument.DocumentPath.Substring(uploadsIndex));

                        if (File.Exists(documentPath))
                        {
                            File.Delete(documentPath);
                        }

                        _context.TblDocument.Remove(oldDocument);
                    }
                }

                post.PostUserGuid = currentUser.UserGuid;
                post.PostTitle = request.Command.Title;
                post.PostAbstract = request.Command.Abstract;
                post.PostDescription = request.Command.Description;
                post.PostIsShow = request.Command.IsShow;
                post.PostModifyDate = DateTime.Now;

                var oldCategories = await _context.TblPostCategory
                    .Where(x => x.PcPostGuid == post.PostGuid)
                    .ToListAsync(cancellationToken);

                foreach (var oldCategory in oldCategories)
                {
                    _context.TblPostCategory.Remove(oldCategory);
                }

                foreach (var categoryGuid in request.Command.Categories)
                {
                    var postCategory = new TblPostCategory()
                    {
                        PcPost = post,
                        PcCategoryGuid = categoryGuid
                    };

                    _context.TblPostCategory.Add(postCategory);
                }

                var oldTags = await _context.TblPostTag
                    .Where(x => x.PtPostGuid == post.PostGuid)
                    .ToListAsync(cancellationToken);

                foreach (var oldTag in oldTags)
                {
                    _context.TblPostTag.Remove(oldTag);
                }

                TblPostTag postTag;

                foreach (var tag in request.Command.Tags)
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

                await _context.SaveChangesAsync(cancellationToken);

                return new UpdatePostCommandVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)UpdatePostState.Success
                };
            }
        }
    }
}

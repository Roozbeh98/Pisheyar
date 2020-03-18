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

        public int[] CategoriesIds { get; set; }

        //public int[] Tags { get; set; }

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
                var postEntity = new TblPost
                {
                    PostUserId = await _context.TblUser.Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier)).Select(x => x.UserId).SingleOrDefaultAsync(cancellationToken),
                    PostTitle = request.Title,
                    PostAbstract = request.Abstract,
                    PostDescription = request.Description,
                    PostIsShow = request.IsShow
                };

                foreach (var categoryId in request.CategoriesIds)
                {
                    var postCategoryEntity = new TblPostCategory()
                    {
                        PcPost = postEntity,
                        PcCategoryId = categoryId
                    };

                    _context.TblPostCategory.Add(postCategoryEntity);
                }

                _context.TblPost.Add(postEntity);

                await _context.SaveChangesAsync(cancellationToken);

                return new CreatePostCommandVm() { Message = "عملیات موفق آمیز", State = (int)CreatePostState.Success };
            }
        }
    }
}

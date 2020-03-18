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

namespace Pisheyar.Application.Posts.Commands.UpdatePost
{
    public class UpdatePostCommand : IRequest<UpdatePostCommandVm>
    {
        public Guid PostGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public bool IsShow { get; set; }

        public int[] CategoriesIds { get; set; }

        //public int[] Tags { get; set; }

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
                var query = await _context.TblPost.SingleOrDefaultAsync(x => x.PostGuid == request.PostGuid && !x.PostIsDelete);

                if (query != null)
                {
                    query.PostUserId = await _context.TblUser.Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier)).Select(x => x.UserId).SingleOrDefaultAsync(cancellationToken);
                    query.PostTitle = request.Title;
                    query.PostAbstract = request.Abstract;
                    query.PostDescription = request.Description;
                    query.PostIsShow = request.IsShow;
                    query.PostModifyDate = DateTime.Now;

                    //foreach (var categoryId in request.CategoriesIds)
                    //{
                    //    var postCategoryEntity = new TblPostCategory()
                    //    {
                    //        PcPost = postEntity,
                    //        PcCategoryId = categoryId
                    //    };

                    //    _context.TblPostCategory.Add(postCategoryEntity);
                    //}

                    await _context.SaveChangesAsync(cancellationToken);

                    return new UpdatePostCommandVm() { Message = "عملیات موفق آمیز", State = (int)UpdatePostState.Success };
                }

                return new UpdatePostCommandVm() { Message = "پست مورد نظر یافت نشد", State = (int)UpdatePostState.PostNotFound };
            }
        }
    }
}

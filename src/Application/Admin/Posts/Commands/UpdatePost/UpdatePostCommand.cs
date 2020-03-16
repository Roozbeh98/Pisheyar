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
    public class UpdatePostCommand : IRequest<int>
    {
        public int PostId { get; set; }

        public int UserId { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public bool IsShow { get; set; }

        public int[] CategoriesIds { get; set; }

        public int[] Tags { get; set; }

        public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, int>
        {
            private readonly IPisheyarMagContext _context;

            public UpdatePostCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
            {
                var query = await _context.TblPost.SingleOrDefaultAsync(x => x.PostId == request.PostId && !x.PostIsDelete);

                if (query != null)
                {
                    query.PostUserId = request.UserId;
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

                    return 1;
                }

                return -1;
            }
        }
    }
}

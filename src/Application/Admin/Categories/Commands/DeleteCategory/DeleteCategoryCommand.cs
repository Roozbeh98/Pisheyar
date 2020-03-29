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

namespace Pisheyar.Application.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryVm>
    {
        public Guid Guid { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryVm>
        {
            private readonly IPisheyarMagContext _context;

            public DeleteCategoryCommandHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<DeleteCategoryVm> RemoveCategoryTree(List<TblCategory> categories, Guid guid, CancellationToken cancellationToken)
            {
                var parent = categories
                    .Where(x => x.CategoryGuid == guid)
                    .SingleOrDefault();

                if (parent != null)
                {
                    int deletedRecordsCount = 1;

                    parent.CategoryIsDelete = true;
                    parent.CategoryModifyDate = DateTime.Now;

                    var children = categories
                    .Where(x => x.CategoryCategoryGuid == guid)
                    .OrderBy(x => x.CategoryOrder)
                    .ToList();

                    foreach (var child in children)
                    {
                        child.CategoryIsDelete = true;
                        child.CategoryModifyDate = DateTime.Now;

                        deletedRecordsCount++;

                        deletedRecordsCount = await RemoveCategoryChildren(categories, child, deletedRecordsCount);
                    }

                    await _context.SaveChangesAsync(cancellationToken);

                    return new DeleteCategoryVm()
                    {
                        Message = "عملیات موفق آمیز",
                        State = (int)DeleteCategoryState.Success,
                        DeletedRecordsCount = deletedRecordsCount
                    };
                }

                return new DeleteCategoryVm()
                {
                    Message = "موردی یافت نشد",
                    State = (int)DeleteCategoryState.NotFound
                };
            }

            private async Task<int> RemoveCategoryChildren(List<TblCategory> categories, TblCategory parent, int deletedRecordsCount)
            {
                var children = categories
                    .Where(x => x.CategoryCategoryGuid == parent.CategoryGuid)
                    .OrderBy(x => x.CategoryOrder)
                    .ToList();

                foreach (var child in children)
                {
                    child.CategoryIsDelete = true;
                    child.CategoryModifyDate = DateTime.Now;

                    deletedRecordsCount++;

                    deletedRecordsCount = await RemoveCategoryChildren(categories, child, deletedRecordsCount);
                }

                return deletedRecordsCount;
            }

            public async Task<DeleteCategoryVm> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var categories = await _context.TblCategory
                    .Where(x => !x.CategoryIsDelete)
                    .ToListAsync(cancellationToken);

                return await RemoveCategoryTree(categories, request.Guid, cancellationToken);
            }
        }
    }
}

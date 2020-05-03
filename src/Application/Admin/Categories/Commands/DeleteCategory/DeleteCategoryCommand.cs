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
            private readonly IPisheyarContext _context;

            public DeleteCategoryCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<DeleteCategoryVm> RemoveCategoryTree(List<Category> categories, Guid guid, CancellationToken cancellationToken)
            {
                var parent = categories
                    .Where(x => x.CategoryGuid == guid)
                    .SingleOrDefault();

                if (parent != null)
                {
                    int deletedRecordsCount = 1;

                    parent.IsDelete = true;
                    parent.ModifiedDate = DateTime.Now;

                    var children = categories
                        .Where(x => x.ParentCategoryId == parent.CategoryId)
                        .OrderBy(x => x.Sort)
                        .ToList();

                    foreach (var child in children)
                    {
                        child.IsDelete = true;
                        child.ModifiedDate = DateTime.Now;

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

            private async Task<int> RemoveCategoryChildren(List<Category> categories, Category parent, int deletedRecordsCount)
            {
                var children = categories
                    .Where(x => x.ParentCategoryId == parent.ParentCategoryId)
                    .OrderBy(x => x.Sort)
                    .ToList();

                foreach (var child in children)
                {
                    child.IsDelete = true;
                    child.ModifiedDate = DateTime.Now;

                    deletedRecordsCount++;

                    deletedRecordsCount = await RemoveCategoryChildren(categories, child, deletedRecordsCount);
                }

                return deletedRecordsCount;
            }

            public async Task<DeleteCategoryVm> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                var categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync(cancellationToken);

                return await RemoveCategoryTree(categories, request.Guid, cancellationToken);
            }
        }
    }
}

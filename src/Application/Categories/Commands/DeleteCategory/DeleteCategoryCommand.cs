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
        public Guid CategoryGuid { get; set; }

        public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryVm>
        {
            private readonly IPisheyarContext _context;
            private readonly DateTime now = DateTime.Now;

            public DeleteCategoryCommandHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<DeleteCategoryVm> RemoveCategory(Guid parentGuid)
            {
                List<Category> categories = await _context.Category
                    .Where(x => !x.IsDelete)
                    .ToListAsync();

                if (categories.Count <= 0) return new DeleteCategoryVm()
                {
                    Message = "دسته بندی ای یافت نشد",
                    State = (int)DeleteCategoryState.NotAnyCategoriesFound
                };

                Category category = categories
                    .Where(x => x.CategoryGuid == parentGuid && !x.IsDelete)
                    .SingleOrDefault();

                if (category == null) return new DeleteCategoryVm()
                {
                    Message = "دسته بندی مورد نظر یافت نشد",
                    State = (int)DeleteCategoryState.CategoryNotFound
                };

                category.IsDelete = true;
                category.ModifiedDate = now;

                int deletedRecordsCount = 1;

                deletedRecordsCount = await RemoveCategoryChildren(categories, category, deletedRecordsCount);

                await _context.SaveChangesAsync(new CancellationToken());

                return new DeleteCategoryVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)DeleteCategoryState.Success,
                    DeletedRecordsCount = deletedRecordsCount
                };
            }

            private async Task<int> RemoveCategoryChildren(List<Category> categories, Category category, int deletedRecordsCount)
            {
                List<Category> subCategories = categories
                    .Where(x => x.ParentCategoryId == category.CategoryId && !x.IsDelete)
                    .OrderBy(x => x.Sort)
                    .ToList();

                foreach (Category subCategory in subCategories)
                {
                    subCategory.IsDelete = true;
                    subCategory.ModifiedDate = now;

                    deletedRecordsCount++;

                    deletedRecordsCount = await RemoveCategoryChildren(categories, subCategory, deletedRecordsCount);
                }

                return deletedRecordsCount;
            }

            public async Task<DeleteCategoryVm> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                return await RemoveCategory(request.CategoryGuid);
            }
        }
    }
}

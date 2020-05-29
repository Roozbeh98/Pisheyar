using MediatR;
using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using Pisheyar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Application.Categories.Commands.SetCategoryDetails
{
    public class SetCategoryDetailsCommand : IRequest<SetCategoryDetailsVm>
    {
        public Guid CategoryGuid { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public string CoverDocumentGuid { get; set; }

        public string ActiveIconDocumentGuid { get; set; }

        public string InactiveIconDocumentGuid { get; set; }

        public string QuadMenuDocumentGuid { get; set; }

        public string[] Tags { get; set; }

        public class SetCategoryDetailsQueryHandler : IRequestHandler<SetCategoryDetailsCommand, SetCategoryDetailsVm>
        {
            private readonly IPisheyarContext _context;

            public SetCategoryDetailsQueryHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<SetCategoryDetailsVm> Handle(SetCategoryDetailsCommand request, CancellationToken cancellationToken)
            {
                Category category = await _context.Category
                    .SingleOrDefaultAsync(x => x.CategoryGuid == request.CategoryGuid, cancellationToken);

                if (category == null) return new SetCategoryDetailsVm
                {
                    Message = "دسته بندی مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.CategoryNotFound
                };

                Document coverDocument = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.CoverDocumentGuid), cancellationToken);

                if (coverDocument == null) return new SetCategoryDetailsVm()
                {
                    Message = "تصویر کاور مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.CoverDocumentNotFound
                };

                Document activeIconDocument = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.ActiveIconDocumentGuid), cancellationToken);

                if (activeIconDocument == null) return new SetCategoryDetailsVm()
                {
                    Message = "تصویر آیکون فعال مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.ActiveIconDocumentNotFound
                };

                Document inactiveIconDocument = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.InactiveIconDocumentGuid), cancellationToken);

                if (inactiveIconDocument == null) return new SetCategoryDetailsVm()
                {
                    Message = "تصویر آیکون غیرفعال مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.InactiveIconDocumentNotFound
                };

                Document quadMenuDocument = await _context.Document
                    .SingleOrDefaultAsync(x => x.DocumentGuid == Guid.Parse(request.QuadMenuDocumentGuid), cancellationToken);

                if (quadMenuDocument == null) return new SetCategoryDetailsVm()
                {
                    Message = "تصویر فهرست چرخشی مورد نظر یافت نشد",
                    State = (int)SetCategoryDetailsState.QuadMenuDocumentNotFound
                };

                category.Abstract = request.Abstract;
                category.Description = request.Description;
                category.CoverDocumentId = coverDocument.DocumentId;
                category.ActiveIconDocumentId = activeIconDocument.DocumentId;
                category.InactiveIconDocumentId = inactiveIconDocument.DocumentId;
                category.QuadMenuDocumentId = quadMenuDocument.DocumentId;
                category.ModifiedDate = DateTime.Now;

                CategoryTag categoryTag;

                foreach (string tag in request.Tags)
                {
                    Guid.TryParse(tag, out Guid guid);

                    if (guid == Guid.Empty)
                    {
                        Tag newTag = new Tag()
                        {
                            Name = tag
                        };

                        _context.Tag.Add(newTag);

                        categoryTag = new CategoryTag()
                        {
                            CategoryId = category.CategoryId
                        };

                        categoryTag.Tag = newTag;
                    }
                    else
                    {
                        Tag availableTeg = await _context.Tag
                            .Where(x => x.TagGuid == Guid.Parse(tag))
                            .SingleOrDefaultAsync(cancellationToken);

                        if (availableTeg == null) continue;

                        categoryTag = new CategoryTag()
                        {
                            CategoryId = category.CategoryId,
                            TagId = availableTeg.TagId
                        };
                    }

                    _context.CategoryTag.Add(categoryTag);
                }

                await _context.SaveChangesAsync(cancellationToken);

                return new SetCategoryDetailsVm()
                {
                    Message = "عملیات موفق آمیز",
                    State = (int)SetCategoryDetailsState.Success
                };
            }
        }
    }
}

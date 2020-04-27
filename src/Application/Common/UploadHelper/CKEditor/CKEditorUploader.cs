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
using Microsoft.AspNetCore.Http;

namespace Pisheyar.Application.Common.UploadHelper.CKEditor
{
    public class CKEditorUploader : IRequest<CKEditorDto>
    {
        public IFormFile File { get; set; }

        public string WebRootPath { get; set; }

        public class CKEditorUploaderHandler : IRequestHandler<CKEditorUploader, CKEditorDto>
        {
            private readonly IPisheyarContext _context;

            public CKEditorUploaderHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<CKEditorDto> Handle(CKEditorUploader request, CancellationToken cancellationToken)
            {
                var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + request.File.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, "Uploads", filename);
                var stream = new FileStream(path, FileMode.Create);
                await request.File.CopyToAsync(stream);

                var typeCode = await _context.Code
                    .Where(x => x.Name.Equals(request.File.ContentType) && !x.IsDelete)
                    .SingleOrDefaultAsync(cancellationToken);

                if (typeCode == null)
                {
                    return new CKEditorDto
                    {
                        Url = null
                    };
                }

                var document = new Document
                {
                    TypeCodeId = typeCode.CodeId,
                    Path = Path.Combine("http://185.94.97.164", "Uploads", filename),
                    Size = request.File.Length,
                    Name = filename
                };

                _context.Document.Add(document);

                await _context.SaveChangesAsync(cancellationToken);

                return new CKEditorDto
                {
                    Url = document.Path
                };
            }
        }
    }
}

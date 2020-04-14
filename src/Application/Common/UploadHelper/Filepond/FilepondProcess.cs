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

namespace Pisheyar.Application.Common.UploadHelper.Filepond
{
    public class FilepondProcess : IRequest<Guid?>
    {
        public IFormFile Filepond { get; set; }

        public string WebRootPath { get; set; }

        public class FilepondProcessHandler : IRequestHandler<FilepondProcess, Guid?>
        {
            private readonly IPisheyarMagContext _context;

            public FilepondProcessHandler(IPisheyarMagContext context)
            {
                _context = context;
            }

            public async Task<Guid?> Handle(FilepondProcess request, CancellationToken cancellationToken)
            {
                var filename = DateTime.Now.ToString("yyyyMMddHHmmss") + request.Filepond.FileName;
                var path = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, "Uploads", filename);
                var stream = new FileStream(path, FileMode.Create);
                await request.Filepond.CopyToAsync(stream);

                var typeCode = _context.TblCode
                    .Where(x => x.CodeName.Equals(request.Filepond.ContentType) && !x.CodeIsDelete)
                    .SingleOrDefaultAsync(cancellationToken);
                
                if (typeCode.Result == null) return null;
               
                var document = new TblDocument
                {
                    DocumentTypeCodeId = typeCode.Result.CodeId,
                    DocumentPath = Path.Combine("http://185.94.97.164", "Uploads", filename),
                    DocumentSize = request.Filepond.Length.ToString(),
                    DocumentFileName = filename
                };

                _context.TblDocument.Add(document);

                await _context.SaveChangesAsync(cancellationToken);

                return document.DocumentGuid;
            }
        }
    }
}

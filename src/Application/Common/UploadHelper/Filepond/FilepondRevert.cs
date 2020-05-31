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
    public class FilepondRevert : IRequest<bool>
    {
        public Stream Body { get; set; }

        public string WebRootPath { get; set; }

        public class FilepondRevertHandler : IRequestHandler<FilepondRevert, bool>
        {
            private readonly IPisheyarContext _context;

            public FilepondRevertHandler(IPisheyarContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(FilepondRevert request, CancellationToken cancellationToken)
            {
                string res;

                MemoryStream memstream = new MemoryStream();
                await request.Body.CopyToAsync(memstream);
                memstream.Position = 0;
                using (StreamReader reader = new StreamReader(memstream))
                {
                    res = reader.ReadToEnd();
                }

                res = res.Remove(res.Length - 1);
                string filename = res.Substring(1);

                var source = Path.Combine(Directory.GetCurrentDirectory(), request.WebRootPath, "Uploads", filename);

                if (File.Exists(source))
                {
                    //File.Delete(source);
                    return true;
                }

                return false;
            }
        }
    }
}

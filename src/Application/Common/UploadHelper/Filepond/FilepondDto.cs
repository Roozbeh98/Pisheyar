using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Common.UploadHelper.Filepond
{
    public class FilepondDto
    {
        public string Source { get; set; }

        public FilepondOptions Options { get; set; }
    }

    public class FilepondOptions
    {
        public string Type { get; set; }

        public FilepondFile Files { get; set; }

        public FilepondMetadata Metadata { get; set; }
    }

    public class FilepondFile
    {
        public string Name { get; set; }

        public string Size { get; set; }

        public string Type { get; set; }
    }

    public class FilepondMetadata
    {
        public string Poster { get; set; }
    }
}

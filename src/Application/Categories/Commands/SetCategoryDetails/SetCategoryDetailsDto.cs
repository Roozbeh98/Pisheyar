using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Commands.SetCategoryDetails
{
    public class SetCategoryDetailsDto
    {
        public Guid CategoryGuid { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public string CoverDocumentGuid { get; set; }

        public string ActiveIconDocumentGuid { get; set; }

        public string InactiveIconDocumentGuid { get; set; }

        public string QuadMenuDocumentGuid { get; set; }

        public string[] Tags { get; set; }
    }
}

using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Application.Common.UploadHelper.Filepond;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pisheyar.Application.Categories.Queries.GetPrimaryCategories
{
    public class PrimaryCategoryDto
    {
        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public FilepondDto CoverDocument { get; set; }

        public FilepondDto ActiveIconDocument { get; set; }

        public FilepondDto InactiveIconDocument { get; set; }

        public FilepondDto QuadMenuDocument { get; set; }

        public List<GetPrimaryCategoryTagNameDto> Tags { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<PrimaryCategoryDto> Children { get; set; }
    }

    public class GetPrimaryCategoryTagNameDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

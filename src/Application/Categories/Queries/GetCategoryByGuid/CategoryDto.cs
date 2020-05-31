using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Application.Common.UploadHelper.Filepond;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Categories.Queries.GetCategoryByGuid
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        public Guid CategoryGuid { get; set; }

        public string Title { get; set; }

        public string Abstract { get; set; }

        public string Description { get; set; }

        public int Sort { get; set; }

        public FilepondDto CoverDocument { get; set; }

        public FilepondDto ActiveIconDocument { get; set; }

        public FilepondDto InactiveIconDocument { get; set; }

        public FilepondDto QuadMenuDocument { get; set; }

        public List<GetCategoryTagNameDto> Tags { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<CategoryDto> Children { get; set; }
    }

    public class CategoryDtoResult
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

        public List<GetCategoryTagNameDto> Tags { get; set; }

        public bool IsActive { get; set; }

        public string ModifiedDate { get; set; }

        public List<CategoryDto> Children { get; set; }
    }

    public class GetCategoryTagNameDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

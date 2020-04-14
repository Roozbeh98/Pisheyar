using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostCategoryDto
    {
        public Guid Guid { get; set; }

        public Guid? ParentGuid { get; set; }

        public string Title { get; set; }

        public int Order { get; set; }

        public List<GetPostCategoryDto> Children { get; set; } = new List<GetPostCategoryDto>();
    }
}

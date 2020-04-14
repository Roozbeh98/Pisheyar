using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostCategoryVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public List<GetPostCategoryDto> Categories { get; set; } = new List<GetPostCategoryDto>();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<GetPostsByCategoryDto> Posts { get; set; }
    }
}

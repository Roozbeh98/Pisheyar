using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<GetAllPostDto> Posts { get; set; }
    }
}

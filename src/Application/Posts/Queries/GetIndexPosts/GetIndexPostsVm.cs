using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetIndexPosts
{
    public class GetIndexPostsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetIndexPostsDto> Posts { get; set; }
    }
}

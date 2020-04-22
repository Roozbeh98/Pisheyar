using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetMostViewedPosts
{
    public class GetMostViewedPostsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetMostViewedPostsDto> Posts { get; set; }
    }
}

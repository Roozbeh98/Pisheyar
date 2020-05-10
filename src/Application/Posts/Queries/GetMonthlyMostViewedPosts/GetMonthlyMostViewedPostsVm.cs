using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetMonthlyMostViewedPosts
{
    public class GetMonthlyMostViewedPostsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetMonthlyMostViewedPostsDto> Posts { get; set; }
    }
}

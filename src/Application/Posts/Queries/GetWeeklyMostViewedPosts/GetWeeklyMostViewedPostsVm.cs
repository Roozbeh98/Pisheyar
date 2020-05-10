using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetWeeklyMostViewedPosts
{
    public class GetWeeklyMostViewedPostsVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public IEnumerable<GetWeeklyMostViewedPostsDto> Posts { get; set; }
    }
}

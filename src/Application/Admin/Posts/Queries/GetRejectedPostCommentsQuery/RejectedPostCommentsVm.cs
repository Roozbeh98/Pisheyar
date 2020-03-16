using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery
{
    public class RejectedPostCommentsVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<RejectedPostCommentDto> PostComments { get; set; }
    }
}

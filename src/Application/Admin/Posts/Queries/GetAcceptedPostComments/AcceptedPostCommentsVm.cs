using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetAcceptedPostComments
{
    public class AcceptedPostCommentsVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<AcceptedPostCommentDto> PostComments { get; set; }
    }
}

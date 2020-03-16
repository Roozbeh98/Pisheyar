using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public GetPostDto Post { get; set; }
    }
}

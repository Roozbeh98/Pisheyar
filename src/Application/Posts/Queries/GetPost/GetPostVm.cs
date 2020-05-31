using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public GetPostDto Post { get; set; }
    }
}

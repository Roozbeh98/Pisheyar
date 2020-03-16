using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Posts.Queries.GetPostsByPagination
{
    public class GetPostsByPaginationVm
    {
        public string Message { get; set; }

        public bool Result { get; set; }

        public IEnumerable<GetPostsByPaginationDto> Posts { get; set; }
    }
}

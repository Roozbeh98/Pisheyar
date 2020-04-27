using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetPostsByPagination
{
    public class GetPostsByPaginationDto : IMapFrom<Post>
    {
        public Guid PostGuid { get; set; }

        public string UserFullName { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public DateTime PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }
    }
}

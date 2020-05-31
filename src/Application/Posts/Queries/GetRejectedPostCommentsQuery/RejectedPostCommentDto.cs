using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery
{
    public class RejectedPostCommentDto : IMapFrom<PostComment>
    {
        public Guid PcGuid { get; set; }

        public string UserFullName { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<PostComment, RejectedPostCommentDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.Comment.User.FirstName + " " + s.Comment.User.LastName))
                .ForMember(d => d.CommentText, opt => opt.MapFrom(s => s.Comment.Message))
                .ForMember(d => d.CommentDate, opt => opt.MapFrom(s => s.Comment.ModifiedDate));
        }
    }
}

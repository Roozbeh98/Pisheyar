using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetRejectedPostCommentsQuery
{
    public class RejectedPostCommentDto : IMapFrom<TblPostComment>
    {
        public Guid PcGuid { get; set; }

        public string UserFullName { get; set; }

        public string CommentText { get; set; }

        public DateTime CommentDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblPostComment, RejectedPostCommentDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.PcComment.CommentUser.UserName + " " + s.PcComment.CommentUser.UserFamily))
                .ForMember(d => d.CommentText, opt => opt.MapFrom(s => s.PcComment.CommentText))
                .ForMember(d => d.CommentDate, opt => opt.MapFrom(s => s.PcComment.CommentDate));
        }
    }
}

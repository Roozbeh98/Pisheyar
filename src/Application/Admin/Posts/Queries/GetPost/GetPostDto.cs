using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostDto : IMapFrom<TblPost>
    {
        public Guid PostGuid { get; set; }

        public string UserFullName { get; set; }

        public string DocumentFileName { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public string PostAbstract { get; set; }

        public string PostDescription { get; set; }

        public DateTime PostCreateDate { get; set; }

        public DateTime PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblPost, GetPostDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.PostUser.UserName + " " + s.PostUser.UserFamily))
                .ForMember(d => d.DocumentFileName, opt => opt.MapFrom(s => s.PostDocument.DocumentFileName));
        }
    }
}

using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostDto : IMapFrom<TblPost>
    {
        public Guid PostGuid { get; set; }

        public string UserFullName { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public string PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblPost, GetAllPostDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.PostUser.UserName + " " + s.PostUser.UserFamily))
                .ForMember(d => d.PostModifyDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.PostModifyDate, "yyyy/MM/dd HH:mm")));
        }
    }
}

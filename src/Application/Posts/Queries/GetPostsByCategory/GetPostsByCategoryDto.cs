using AutoMapper;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Posts.Queries.GetPostsByCategory
{
    public class GetPostsByCategoryDto : IMapFrom<Post>
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

        public bool? PostIsShow { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, GetPostsByCategoryDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName))
                .ForMember(d => d.DocumentFileName, opt => opt.MapFrom(s => s.Document.Name));
        }
    }
}

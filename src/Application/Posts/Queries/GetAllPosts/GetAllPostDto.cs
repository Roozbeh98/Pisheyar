using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Application.Common.UploadHelper.Filepond;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pisheyar.Application.Posts.Queries.GetAllPosts
{
    public class GetAllPostDto : IMapFrom<Post>
    {
        public Guid PostGuid { get; set; }

        public FilepondDto Document { get; set; }

        public GetAllPostCategoryNameDto Category { get; set; }

        public List<GetAllPostTagNameDto> Tags { get; set; }

        public string UserFullName { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public string PostAbstract { get; set; }

        public string PostDescription { get; set; }

        public string PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }

        public string Slug { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, GetAllPostDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.User.FirstName + " " + s.User.LastName))
                .ForMember(d => d.PostModifyDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")))
                .ForMember(d => d.Slug, opt => opt.MapFrom(s => s.Title.Trim().ToLowerInvariant().Replace(" ", "-")))
                .ForMember(d => d.Document, opt => opt.MapFrom(s => new FilepondDto
                {
                    Source = s.Document.Path,
                    Options = new FilepondOptions
                    {
                        Type = "local",
                        Files = new FilepondFile
                        {
                            Name = s.Document.Name,
                            Size = s.Document.Size.ToString(),
                            Type = s.Document.TypeCode.Name
                        },
                        Metadata = new FilepondMetadata
                        {
                            Poster = s.Document.Path
                        }
                    }
                }));
        }
    }

    public class GetAllPostCategoryNameDto
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }
    }

    public class GetAllPostTagNameDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

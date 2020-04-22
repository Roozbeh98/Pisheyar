using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Application.Common.UploadHelper.Filepond;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Pisheyar.Application.Posts.Queries.GetPost
{
    public class GetPostDto : IMapFrom<TblPost>
    {
        public Guid PostGuid { get; set; }

        public FilepondDto Document { get; set; }

        public GetPostCategoryNameDto Category { get; set; }

        public List<GetPostTagNameDto> Tags { get; set; }

        public string UserFullName { get; set; }

        public int PostViewCount { get; set; }

        public int PostLikeCount { get; set; }

        public string PostTitle { get; set; }

        public string PostAbstract { get; set; }

        public string PostDescription { get; set; }

        public string PostCreateDate { get; set; }

        public string PostModifyDate { get; set; }

        public bool PostIsShow { get; set; }

        public string Slug { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TblPost, GetPostDto>()
                .ForMember(d => d.UserFullName, opt => opt.MapFrom(s => s.PostUser.UserName + " " + s.PostUser.UserFamily))
                .ForMember(d => d.PostCreateDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.PostCreateDate, "yyyy/MM/dd HH:mm")))
                .ForMember(d => d.PostModifyDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.PostModifyDate, "yyyy/MM/dd HH:mm")))
                .ForMember(d => d.Slug, opt => opt.MapFrom(s => s.PostTitle.Trim().ToLowerInvariant().Replace(" ", "-")))
                .ForMember(d => d.Document, opt => opt.MapFrom(s => new FilepondDto
                {
                    Source = s.PostDocument.DocumentPath,
                    Options = new FilepondOptions
                    {
                        Type = "local",
                        Files = new FilepondFile
                        {
                            Name = s.PostDocument.DocumentFileName,
                            Size = s.PostDocument.DocumentSize,
                            Type = s.PostDocument.DocumentTypeCode.CodeName
                        },
                        Metadata = new FilepondMetadata
                        {
                            Poster = s.PostDocument.DocumentPath
                        }
                    }
                }));
        }
    }

    public class GetPostCategoryNameDto
    {
        public Guid Guid { get; set; }

        public string Title { get; set; }
    }

    public class GetPostTagNameDto
    {
        public Guid Guid { get; set; }

        public string Name { get; set; }
    }
}

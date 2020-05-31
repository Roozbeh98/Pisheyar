using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Application.Posts.Queries.GetAllPosts;
using Pisheyar.Domain.Entities;
using System;

namespace Pisheyar.Application.Accounts.Queries.GetAllUsers
{
    public class UserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string UserName { get; set; }

        public string UserFamily { get; set; }

        public string UserCreateDate { get; set; }

        public bool UserIsActive { get; set; }

        public bool UserIsBan { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDto>()
                .ForMember(d => d.UserCreateDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }
}

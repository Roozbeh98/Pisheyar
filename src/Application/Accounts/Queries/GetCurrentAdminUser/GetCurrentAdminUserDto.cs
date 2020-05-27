using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Linq;
using AutoMapper;
using Pisheyar.Application.Accounts.Queries.GetCurrentContractorUser;
using Pisheyar.Application.Common;

namespace Pisheyar.Application.Accounts.Queries.GetCurrentAdminUser
{
    public class GetCurrentAdminUserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public CurrentAdminUserGenderDto Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsRegister { get; set; }

        public bool IsActive { get; set; }

        public string RegisteredDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetCurrentAdminUserDto>()
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => new CurrentAdminUserGenderDto
                {
                    GenderGuid = s.GenderCode.CodeGuid,
                    Name = s.GenderCode.DisplayName
                }))
                .ForMember(d => d.RegisteredDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }

    public class CurrentAdminUserGenderDto
    {
        public Guid GenderGuid { get; set; }

        public string Name { get; set; }
    }
}

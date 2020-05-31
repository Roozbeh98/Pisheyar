using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Linq;
using AutoMapper;
using Pisheyar.Application.Common;

namespace Pisheyar.Application.Accounts.Queries.GetCurrentClientUser
{
    public class GetCurrentClientUserDto : IMapFrom<User>
    {
        public Guid UserGuid { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Gender { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public CurrentClientUserCityDto City { get; set; }

        public bool IsRegister { get; set; }

        public bool IsActive { get; set; }

        public string RegisteredDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, GetCurrentClientUserDto>()
                .ForMember(d => d.Gender, opt => opt.MapFrom(s => s.GenderCode.DisplayName))
                .ForMember(d => d.City, opt => opt.MapFrom(s => new CurrentClientUserCityDto
                {
                    CityGuid = s.Client.SingleOrDefault().City.CityGuid,
                    Name = s.Client.SingleOrDefault().City.Name
                }))
                .ForMember(d => d.RegisteredDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.RegisteredDate, "yyyy/MM/dd HH:mm")));
        }
    }

    public class CurrentClientUserCityDto
    {
        public Guid CityGuid { get; set; }

        public string Name { get; set; }
    }
}

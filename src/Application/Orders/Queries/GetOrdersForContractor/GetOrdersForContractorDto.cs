using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Orders.Queries.GetOrdersForContractor
{
    public class GetOrdersForContractorDto : IMapFrom<Order>
    {
        public Guid OrderGuid { get; set; }

        public string Client { get; set; }

        public string Category { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetOrdersForContractorDto>()
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Client.User.FirstName + " " + s.Client.User.LastName))
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}

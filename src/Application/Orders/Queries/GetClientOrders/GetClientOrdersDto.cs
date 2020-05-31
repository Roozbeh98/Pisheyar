using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Orders.Queries.GetClientOrders
{
    public class GetClientOrdersDto : IMapFrom<Order>
    {
        public Guid OrderGuid { get; set; }

        public string Category { get; set; }

        //public string Contractor { get; set; }

        public int RequestsCount { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string State { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, GetClientOrdersDto>()
                .ForMember(d => d.Category, opt => opt.MapFrom(s => s.Category.DisplayName))
                //.ForMember(d => d.Contractor, opt => opt.MapFrom(s => s.Contractor.User.FirstName + " " + s.Contractor.User.LastName))
                .ForMember(d => d.RequestsCount, opt => opt.MapFrom(s => s.OrderRequest.Count))
                .ForMember(d => d.State, opt => opt.MapFrom(s => s.StateCode.DisplayName))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}

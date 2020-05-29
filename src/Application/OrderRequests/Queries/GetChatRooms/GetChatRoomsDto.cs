using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetChatRooms
{
    public class GetChatRoomsDto : IMapFrom<OrderRequest>
    {
        public Guid OrderRequestGuid { get; set; }

        public string Client { get; set; }

        public string RecentMessage { get; set; }

        public bool IsAllow { get; set; }

        public string ModifiedDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<OrderRequest, GetChatRoomsDto>()
                .ForMember(d => d.Client, opt => opt.MapFrom(s => s.Order.Client.User.FirstName + " " + s.Order.Client.User.LastName))
                .ForMember(d => d.RecentMessage, opt => opt.MapFrom(s => s.ChatMessage.OrderByDescending(x => x.ModifiedDate).FirstOrDefault().Text))
                .ForMember(d => d.IsAllow, opt => opt.MapFrom(s => s.IsAllow))
                .ForMember(d => d.ModifiedDate, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.ModifiedDate, "yyyy/MM/dd HH:mm")));
        }
    }
}

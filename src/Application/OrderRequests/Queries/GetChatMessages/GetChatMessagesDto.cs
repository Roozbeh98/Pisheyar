using AutoMapper;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Mappings;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.OrderRequests.Queries.GetChatMessages
{
    public class GetChatMessagesDto : IMapFrom<ChatMessage>
    {
        public Guid ChatMessageGuid { get; set; }

        public string Text { get; set; }

        public string SentAt { get; set; }

        public string From { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ChatMessage, GetChatMessagesDto>()
                .ForMember(d => d.From, opt => opt.MapFrom(s => s.User.Role.DisplayName))
                .ForMember(d => d.SentAt, opt => opt.MapFrom(s => PersianDateExtensionMethods.ToPeString(s.SentAt, "yyyy/MM/dd HH:mm")));
        }
    }
}

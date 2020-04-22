using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.SignalRHubs
{
    [Authorize]
    public class AgentHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IHubContext<ChatHub> _chatHub;

        public AgentHub(IChatRoomService chatRoomService, IHubContext<ChatHub> chatHub)
        {
            _chatRoomService = chatRoomService;
            _chatHub = chatHub;
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
            await base.OnConnectedAsync();
        }

        public async Task SendMessage(Guid roomId, string text)
        {
            var message = new TblChatMessage
            {
                ChatRoomGuid = roomId,
                //SendAt = DateTimeOffset.UtcNow,
                SenderName = Context.User.Identity.Name,
                Text = text
            };

            await _chatRoomService.AddMessage(roomId, message);

            await _chatHub.Clients.Group(roomId.ToString())
                .SendAsync("ReceiveMessage", message.SenderName, message.SentDate, message.Text);
        }

        public async Task LoadMessagesHistory(Guid roomId)
        {
            var history = await _chatRoomService.GetAllMessages(roomId);
            await Clients.Caller.SendAsync("ReceiveMessages", history);
        }
    }
}

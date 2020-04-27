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
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatRoomService;
        private readonly IHubContext<AgentHub> _agentHub;

        public ChatHub(IChatRoomService chatRoomService, IHubContext<AgentHub> agentHub)
        {
            _chatRoomService = chatRoomService;
            _agentHub = agentHub;
        }

        public override async Task OnConnectedAsync()
        {
            //if (Context.User.Identity.IsAuthenticated)
            //{
            //    await base.OnConnectedAsync();
            //    return;
            //}

            var roomId = await _chatRoomService.CreateRoom(Context.ConnectionId);

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
            await Clients.Caller.SendAsync("ReceiveMessage", "پشتیبانی", DateTimeOffset.UtcNow, "سلام, خوش آمدید!");

            await base.OnConnectedAsync();
        }

        public async Task SendMessage(string name, string text)
        {
            var roomId = await _chatRoomService.GetRoom(Context.ConnectionId);

            var message = new ChatMessage
            {
                //ChatRoomGuid = roomId,
                //SenderName = name,
                Text = text,
                //SendAt = DateTimeOffset.Now
            };

            await _chatRoomService.AddMessage(roomId, message);

            await Clients.Group(roomId.ToString()).SendAsync("ReceiveMessage", message.UserId, message.SentDate, message.Text);
        }

        public async Task SetRoomName(string visitorName)
        {
            var roomId = await _chatRoomService.GetRoom(Context.ConnectionId);

            await _chatRoomService.SetRoomName(roomId, visitorName);
            await _agentHub.Clients.All.SendAsync("ActiveRooms", await _chatRoomService.GetAllRooms());
        }

        //[Authorize]
        public async Task JoinRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            await Groups.AddToGroupAsync(Context.ConnectionId, roomId.ToString());
        }

        //[Authorize]
        public async Task LeaveRoom(Guid roomId)
        {
            if (roomId == Guid.Empty)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomId.ToString());
        }
    }
}

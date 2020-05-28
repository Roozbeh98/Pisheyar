using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using Pisheyar.Application.Common;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebUI.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        private readonly IChatRoomService _chatRoom;
        private readonly ICurrentUserService _currentUser;

        public ChatHub(IChatRoomService chatRoom,
            ICurrentUserService currentUser)
        {
            _chatRoom = chatRoom;
            _currentUser = currentUser;
        }

        public async Task SendMessageAsync(Guid orderRequestGuid, string text)
        {
            User currentUser = await _currentUser.GetInfoAsync();
            OrderRequest orderRequest = await _chatRoom.GetOrderRequestAsync(orderRequestGuid);

            if (await _chatRoom.IsOrderRequestAccessibleAsync(orderRequest))
            {
                ChatMessage chatMessage = await _chatRoom.CreateMessageAsync(orderRequest.OrderRequestId, text, currentUser.UserId);
                string clientName = chatMessage.User.FirstName + " " + chatMessage.User.LastName;
                string sentAt = PersianDateExtensionMethods.ToPeString(chatMessage.SentAt, "yyyy/MM/dd HH:mm");

                await Clients.Group(orderRequestGuid.ToString())
                    .SendAsync("ReceiveMessage", clientName, chatMessage.Text, sentAt, _currentUser.Role);
            }
            else
                throw new NotSupportedException("Order Is Closed");
        }

        public async Task JoinRoomAsync(Guid orderRequestGuid)
        {
            OrderRequest orderRequest = await _chatRoom.GetOrderRequestAsync(orderRequestGuid);

            if (await _chatRoom.IsOrderRequestAccessibleAsync(orderRequest))
                await Groups.AddToGroupAsync(Context.ConnectionId, orderRequestGuid.ToString());
            else
                throw new NotSupportedException("Order Is Closed");
        }

        public async Task LeaveRoomAsync(Guid orderRequestGuid)
        {
            if (await _chatRoom.OrderRequestExistsAsync(orderRequestGuid))
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, orderRequestGuid.ToString());
            else
                throw new ArgumentException("Invalid Order Request GUID");
        }
    }
}

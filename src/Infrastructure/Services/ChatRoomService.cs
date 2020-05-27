using Microsoft.EntityFrameworkCore;
using Pisheyar.Application.Common.Exceptions;
using Pisheyar.Application.Common.Interfaces;
using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pisheyar.Infrastructure.Services
{
    public class ChatRoomService : IChatRoomService
    {
        private readonly IPisheyarContext _context;

        public ChatRoomService(IPisheyarContext context)
        {
            _context = context;
        }

        #region OrderRequest

        public async Task<bool> OrderRequestExistsAsync(Guid orderRequestGuid)
        {
            return await _context.OrderRequest
                .AnyAsync(x => x.OrderRequestGuid == orderRequestGuid);
        }

        private async Task<int> GetOrderRequestIdAsync(Guid orderRequestGuid)
        {
            OrderRequest orderRequest = await _context.OrderRequest
                .SingleOrDefaultAsync(x => x.OrderRequestGuid == orderRequestGuid);

            if (orderRequest == null)
            {
                throw new ArgumentException("Invalid Order Request GUID");
            }

            return orderRequest.OrderRequestId;
        }

        #endregion

        public async Task<ChatMessage> CreateMessageAsync(Guid orderRequestGuid, string text, int userId)
        {
            ChatMessage chatMessage = new ChatMessage
            {
                OrderRequestId = await GetOrderRequestIdAsync(orderRequestGuid),
                UserId = userId,
                Text = text
            };

            _context.ChatMessage.Add(chatMessage);
            await _context.SaveChangesAsync(CancellationToken.None);

            return chatMessage;
        }
    }
}

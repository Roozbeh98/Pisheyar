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

        public Task<bool> IsOrderRequestAccessibleAsync(OrderRequest orderRequest)
        {
            return Task.FromResult((orderRequest.Order.StateCodeId == 9
                && orderRequest.IsAllow) ||
                orderRequest.IsAccept);
        }

        public async Task<OrderRequest> GetOrderRequestAsync(Guid orderRequestGuid)
        {
            OrderRequest orderRequest = await _context.OrderRequest
                .Include(x => x.Order)
                .SingleOrDefaultAsync(x => x.OrderRequestGuid == orderRequestGuid);

            if (orderRequest == null)
                throw new ArgumentException("Invalid Order Request GUID");

            return orderRequest;
        }

        #endregion

        public async Task<ChatMessage> CreateMessageAsync(int orderRequestId, string text, int userId)
        {
            ChatMessage chatMessage = new ChatMessage
            {
                OrderRequestId = orderRequestId,
                UserId = userId,
                Text = text
            };

            _context.ChatMessage.Add(chatMessage);
            await _context.SaveChangesAsync(CancellationToken.None);

            return chatMessage;
        }
    }
}

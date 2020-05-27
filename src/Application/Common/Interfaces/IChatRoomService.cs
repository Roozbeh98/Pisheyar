using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IChatRoomService
    {
        Task<bool> OrderRequestExistsAsync(Guid orderRequestGuid);

        Task<ChatMessage> CreateMessageAsync(Guid orderRequestGuid, string message, int userId);
    }
}

using Pisheyar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pisheyar.Application.Common.Interfaces
{
    public interface IChatRoomService
    {
        Task<Guid> CreateRoom(string connectionId);

        Task<Guid> GetRoom(string connectionId);

        Task SetRoomName(Guid roomId, string name);

        Task AddMessage(Guid roomId, TblChatMessage message);

        Task<List<TblChatMessage>> GetAllMessages(Guid roomId);

        Task<IReadOnlyList<TblChatRoom>> GetAllRooms();
    }
}

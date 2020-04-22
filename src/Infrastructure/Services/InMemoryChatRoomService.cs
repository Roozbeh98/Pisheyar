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
    public class InMemoryChatRoomService : IChatRoomService
    {
        //private readonly Dictionary<Guid, ChatRoom> _roomInfo = new Dictionary<Guid, ChatRoom>();
        //private readonly Dictionary<Guid, List<ChatMessage>> _messages = new Dictionary<Guid, List<ChatMessage>>();
        private readonly IPisheyarMagContext _context;
        private readonly ICurrentUserService _currentUserService;

        public InMemoryChatRoomService(IPisheyarMagContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public Task<Guid> CreateRoom(string connectionId)
        {
            var currentUser = _context.TblUser
                    .Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier))
                    .SingleOrDefault();

            if (currentUser == null)
            {
                throw new UnauthorizedAccessException();
            }

            var chatRoom = new TblChatRoom()
            {
                UserGuid = currentUser.UserGuid,
                OwnerConnectionId = connectionId
            };

            _context.TblChatRoom.Add(chatRoom);
            _context.SaveChanges();

            return Task.FromResult(chatRoom.Guid);
        }

        public Task<Guid> GetRoom(string connectionId)
        {
            var foundRoom = _context.TblChatRoom.FirstOrDefault(x => x.OwnerConnectionId == connectionId);

            if (foundRoom.Guid == null)
            {
                throw new ArgumentException("Invalid Connection ID");
            }

            return Task.FromResult(foundRoom.Guid);
        }

        public Task SetRoomName(Guid roomId, string name)
        {
            //if (!_roomInfo.ContainsKey(roomId))
            //{
            //    throw new ArgumentException("Invalid Room ID");
            //}

            //_roomInfo[roomId].Name = name;

            var chatRoom = _context.TblChatRoom.FirstOrDefault(x => x.Guid == roomId);

            if (chatRoom == null)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            chatRoom.Name = name;

            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddMessage(Guid roomId, TblChatMessage message)
        {
            //if (!_messages.ContainsKey(roomId))
            //{
            //    _messages[roomId] = new List<ChatMessage>();
            //}
            //_messages[roomId].Add(message);
            _context.TblChatMessage.Add(message);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<List<TblChatMessage>> GetAllMessages(Guid roomId)
        {
            var chatMessages = _context.TblChatMessage
                .Where(x => x.Guid == roomId)
                .OrderBy(x => x.SentDate)
                .ToList();

            if (chatMessages == null)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            //_messages.TryGetValue(roomId, out var messages);

            //messages ??= new List<ChatMessage>();
            //var sortedMessages = messages.OrderBy(x => x.SendAt)
            //    .AsEnumerable();

            return Task.FromResult(chatMessages);
        }

        public Task<IReadOnlyList<TblChatRoom>> GetAllRooms()
        {
            var chatRooms = _context.TblChatRoom
                //.OrderBy(x => x.SendAt)
                .ToList();

            return Task.FromResult(chatRooms as IReadOnlyList<TblChatRoom>);
        }
    }
}

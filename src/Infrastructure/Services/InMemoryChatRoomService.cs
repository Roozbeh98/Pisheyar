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
        private readonly IPisheyarContext _context;
        private readonly ICurrentUserService _currentUserService;

        public InMemoryChatRoomService(IPisheyarContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public Task<Guid> CreateRoom(string connectionId)
        {
            var currentUser = _context.User
                    .Where(x => x.UserGuid == Guid.Parse(_currentUserService.NameIdentifier))
                    .SingleOrDefault();

            if (currentUser == null)
            {
                throw new UnauthorizedAccessException();
            }

            var chatRoom = new ChatRoom()
            {
                //UserGuid = currentUser.UserGuid,
                OwnerConnectionId = connectionId
            };

            _context.ChatRoom.Add(chatRoom);
            _context.SaveChanges();

            return Task.FromResult(chatRoom.ChatRoomGuid);
        }

        public Task<Guid> GetRoom(string connectionId)
        {
            var foundRoom = _context.ChatRoom.FirstOrDefault(x => x.OwnerConnectionId == connectionId);

            if (foundRoom.ChatRoomGuid == null)
            {
                throw new ArgumentException("Invalid Connection ID");
            }

            return Task.FromResult(foundRoom.ChatRoomGuid);
        }

        public Task SetRoomName(Guid roomId, string name)
        {
            //if (!_roomInfo.ContainsKey(roomId))
            //{
            //    throw new ArgumentException("Invalid Room ID");
            //}

            //_roomInfo[roomId].Name = name;

            var chatRoom = _context.ChatRoom.FirstOrDefault(x => x.ChatRoomGuid == roomId);

            if (chatRoom == null)
            {
                throw new ArgumentException("Invalid Room ID");
            }

            chatRoom.Name = name;

            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task AddMessage(Guid roomId, ChatMessage message)
        {
            //if (!_messages.ContainsKey(roomId))
            //{
            //    _messages[roomId] = new List<ChatMessage>();
            //}
            //_messages[roomId].Add(message);
            _context.ChatMessage.Add(message);
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task<List<ChatMessage>> GetAllMessages(Guid roomId)
        {
            var chatMessages = _context.ChatMessage
                .Where(x => x.ChatMessageGuid == roomId)
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

        public Task<IReadOnlyList<ChatRoom>> GetAllRooms()
        {
            var chatRooms = _context.ChatRoom
                //.OrderBy(x => x.SendAt)
                .ToList();

            return Task.FromResult(chatRooms as IReadOnlyList<ChatRoom>);
        }
    }
}

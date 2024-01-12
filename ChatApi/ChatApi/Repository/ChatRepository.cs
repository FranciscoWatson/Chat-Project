using ChatApi.Data;
using ChatApi.DTOs;
using ChatApi.Repository.IRepositry;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDBContext _db;
        public ChatRepository(ChatDBContext db)
        {
            _db = db;
        }

        public bool CreateChat(ChatCreationDto chatDto)
        {   Chat chat = new Chat();
            chat.chatName = chatDto.name;
            _db.Chats.Add(chat);
            Save();
            foreach (var userId in chatDto.participantsId)
            {
                UserChat userChat = new UserChat
                {
                    userId = userId,
                    chatId = chat.chatId
                };

                _db.UsersChats.Add(userChat);
            }

            return Save();
        }


        public ICollection<Chat> GetChats()
        {
            return _db.Chats.ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public ICollection<Chat> GetChat(Guid id)
        {

            var userChats = _db.UsersChats
                    .Where(uc => uc.userId == id)
                    .Select(uc => uc.chat)
                    .ToList();


            return userChats;

        }
    }
}

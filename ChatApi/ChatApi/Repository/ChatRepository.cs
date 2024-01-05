using ChatApi.Data;
using ChatApi.Repository.IRepositry;

namespace ChatApi.Repository
{
    public class ChatRepository : IChatRepository
    {
        private readonly ChatDBContext _db;
        public ChatRepository(ChatDBContext db)
        {
            _db = db;
        }

        public bool CreateChat(Chat chat)
        {
            _db.Chats.Add(chat);
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
    }
}

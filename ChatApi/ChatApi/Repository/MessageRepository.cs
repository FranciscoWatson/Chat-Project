﻿using ChatApi.Data;
using ChatApi.Repository.IRepositry;

namespace ChatApi.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ChatDBContext _db;
        public MessageRepository(ChatDBContext db)
        {
            _db = db;
        }

        public bool CreateMessage(Message message)
        {
            _db.Messages.Add(message);
            return Save();
        }
        public Message GetMessage(Guid id)
        {
            return _db.Messages.FirstOrDefault(m => m.messageId == id);
        }

        public ICollection<Message> GetMessages()
        {
            return _db.Messages.ToList();
        }
        public bool DeleteMessage(Message message)
        {
            _db.Messages.Remove(message);
            return Save();
        }

        public bool EditMessage(Message message)
        {
            _db.Messages.Update(message);
            return Save();
        }

        public bool MessageExist(Guid id)
        {
            return (_db.Messages.Any(m => m.messageId == id));
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public ICollection<Message> GetMessages(Guid chatId)
        {

            return _db.Messages.Where(m => m.chatId == chatId).ToList();
        }


    }
}

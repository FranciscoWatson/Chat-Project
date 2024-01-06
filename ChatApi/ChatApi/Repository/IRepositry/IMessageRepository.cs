using ChatApi.Data;

namespace ChatApi.Repository.IRepositry
{
    public interface IMessageRepository
    {
        bool CreateMessage(Message message);
        Message GetMessage(Guid id);
        ICollection<Message> GetMessages();
        bool MessageExist(Guid id);
        bool EditMessage(Message message);
        bool DeleteMessage(Message message);
        bool Save();
    }
}

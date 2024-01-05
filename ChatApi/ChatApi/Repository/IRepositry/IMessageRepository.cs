using ChatApi.Data;

namespace ChatApi.Repository.IRepositry
{
    public interface IMessageRepository
    {

        ICollection<Message> GetMessages();
        bool CreateMessage(Message message);
        bool Save();
    }
}

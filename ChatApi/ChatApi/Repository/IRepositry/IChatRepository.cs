using ChatApi.Data;

namespace ChatApi.Repository.IRepositry
{
    public interface IChatRepository
    {
        ICollection<Chat> GetChats();
        bool CreateChat(Chat chat);
        bool Save();
    }
}

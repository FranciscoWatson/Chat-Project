using ChatApi.Data;
using ChatApi.DTOs;

namespace ChatApi.Repository.IRepositry
{
    public interface IChatRepository
    {
        ICollection<Chat> GetChats();
        public ICollection<Chat> GetChat(Guid id);
        public bool CreateChat(ChatCreationDto chatDto);
        bool Save();
    }
}

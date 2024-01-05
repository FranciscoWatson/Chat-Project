using ChatApi.Data;

namespace ChatApi.Repository.IRepositry
{
    public interface IUserRepository
    {

        ICollection<User> GetUsers();
        User GetUser(Guid id);
        User GetUser(string email);
        bool UserExists(Guid id);
        bool UserExists(string email);
        bool CreateUser(User user);
        bool EditUser(User user);
        bool DeleteUser(User user);
        bool Save();

    }
}

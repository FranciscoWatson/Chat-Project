using ChatApi.Data;
using ChatApi.Repository.IRepositry;

namespace ChatApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ChatDBContext _db;
        public UserRepository(ChatDBContext db)
        {
            _db = db;
        }

        public bool CreateUser(User user)
        {
            _db.Users.Add(user);
            return Save();
        }

        public bool DeleteUser(User user)
        {
            _db.Users.Remove(user);
            return Save();
        }

        public bool EditUser(User user)
        {
            _db.Users.Update(user);
            return Save();
        }

        public User GetUser(Guid id)
        {
            return _db.Users.FirstOrDefault(u => u.userId == id);
        }

        public User GetUser(string email)
        {
            return _db.Users.FirstOrDefault(u => u.email == email);
        }

        public ICollection<User> GetUsers()
        {
            return _db.Users.ToList();
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0;
        }

        public bool UserExists(Guid id)
        {
            return ( _db.Users.Any( u => u.userId == id) );
        }

        public bool UserExists(string email)
        {
            return ( _db.Users.Any(u => u.email.ToLower().Trim() == email.ToLower().Trim()) );
        }
    }
}

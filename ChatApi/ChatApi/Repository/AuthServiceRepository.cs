using ChatApi.Data;
using ChatApi.Repository.IRepositry;
using Microsoft.EntityFrameworkCore;

namespace ChatApi.Repository
{
    public class AuthServiceRepository : IAuthServiceRepository
    {

        private readonly ChatDBContext _db;
        public AuthServiceRepository(ChatDBContext db)
        {
            _db = db;
        }

        public User Authenticate(string userEmail, string password)
        {
            // We should add password hashing later on
            var user = _db.Users.FirstOrDefault(u => u.email == userEmail);
     
            if (user == null || user.password != password)
            {
                return null;
            }

            return user;
        }
    }
}

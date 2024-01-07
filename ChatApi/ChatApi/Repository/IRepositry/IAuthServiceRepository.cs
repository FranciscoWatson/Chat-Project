using ChatApi.Data;

namespace ChatApi.Repository.IRepositry
{
    public interface IAuthServiceRepository
    {
        User Authenticate(string email, string password);
    }
}

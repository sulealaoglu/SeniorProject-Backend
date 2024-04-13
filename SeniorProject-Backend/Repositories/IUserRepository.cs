using SeniorProject_Backend.Models;

namespace SeniorProject_Backend.Repositories
{
    public interface IUserRepository
    {
        User GetUser(string userName,string password);
        bool Register(User user);
        bool UserExist(string userName);
    }
}

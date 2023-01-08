using DatabasesProgrammingExample01.Models;

namespace DatabasesProgrammingExample01.Database.EFCoreUser
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
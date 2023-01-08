using System.Collections.Generic;
using System.Threading.Tasks;
using DatabasesProgrammingExample01.Models;

namespace DatabasesProgrammingExample01.Database.EFCoreUserWithFriends
{
    public interface IUserWithFriendsRepository
    {
        Task<IEnumerable<UserWithFriends>> GetAllUsersWithFriends();
        Task<UserWithFriends> GetUserWithFriendsById(int id);
        Task<ICollection<UserWithFriends>?> GetFriendsOfUser(int id);
        Task AddUserWithFriends(UserWithFriends userWithFriends);
        Task UpdateUserWithFriends(UserWithFriends userWithFriends);
        Task DeleteUserWithFriends(UserWithFriends userWithFriends);
    }
}


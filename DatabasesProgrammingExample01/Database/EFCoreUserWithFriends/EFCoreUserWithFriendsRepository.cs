using System.Collections.Generic;
using System.Threading.Tasks;
using DatabasesProgrammingExample01.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExample01.Database.EFCoreUserWithFriends
{
    public class EFCoreUserWithFriendsRepository : IUserWithFriendsRepository
    {
        private readonly EFCoreUserWithFriendsContext _context;

        public EFCoreUserWithFriendsRepository(EFCoreUserWithFriendsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UserWithFriends>> GetAllUsersWithFriends()
        {
            return await _context.Users.Include(u => u.Friends).ToListAsync();
        }

        public async Task<UserWithFriends> GetUserWithFriendsById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ICollection<UserWithFriends>?> GetFriendsOfUser(int id)
        {
            var test = _context.Users.Include(f => f.Friends)
                .ThenInclude(f => f.Friend).FirstOrDefault(u => u.Id == id);
            return test.Friends.Select(f => f.Friend).ToList();
        }
        public async Task AddUserWithFriends(UserWithFriends userWithFriends)
        {
            await _context.Users.AddAsync(userWithFriends);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserWithFriends(UserWithFriends userWithFriends)
        {
            _context.Users.Update(userWithFriends);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserWithFriends(UserWithFriends userWithFriends)
        {
            _context.Users.Remove(userWithFriends);
            await _context.SaveChangesAsync();
        }
    }
}
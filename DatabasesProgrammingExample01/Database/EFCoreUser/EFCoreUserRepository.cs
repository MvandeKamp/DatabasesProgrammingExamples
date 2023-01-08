using DatabasesProgrammingExample01.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExample01.Database.EFCoreUser
{
    public class EFCoreUserRepository : IUserRepository
    {
        private readonly EFCoreUserContext _context;

        public EFCoreUserRepository(EFCoreUserContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}

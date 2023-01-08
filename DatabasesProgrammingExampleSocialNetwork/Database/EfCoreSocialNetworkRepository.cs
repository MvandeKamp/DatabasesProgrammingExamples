using DatabasesProgrammingExampleSocialNetwork.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace DatabasesProgrammingExampleSocialNetwork.Database
{
    public class EfCoreSocialNetworkRepository
    {
        private readonly EfCoreSocialNetworkContext _context;

        public EfCoreSocialNetworkRepository(EfCoreSocialNetworkContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void RemoveUser(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void AddPost(Post post)
        {
            _context.Users.Where(u => u.Id == post.UserId).First().Posts.Add(post);
            _context.SaveChanges();
        }

        public void RemovePost(Post post)
        {
            _context.Users.Include(p => p.Posts).Where(u => u.Id == post.UserId).First().Posts.Remove(post);
            _context.SaveChanges();
        }

        public Post GetPostById(int id)
        {
            return _context.Users.Include(u => u.Posts).SelectMany(p => p.Posts).Where(p => p.PostId == id).First();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Users.Include(u => u.Posts).SelectMany(p => p.Posts).ToList();
        }

        public void UpdatePost(Post post)
        {
            _context.Update(post);
            _context.SaveChanges();
        }

    }
}

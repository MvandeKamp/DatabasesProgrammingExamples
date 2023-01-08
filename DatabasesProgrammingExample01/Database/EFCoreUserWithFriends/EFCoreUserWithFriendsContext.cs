using DatabasesProgrammingExample01.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExample01.Database.EFCoreUserWithFriends
{
    public class EFCoreUserWithFriendsContext : DbContext
    {
        public DbSet<UserWithFriends> Users { get; set; } = null!;
        public EFCoreUserWithFriendsContext(DbContextOptions<EFCoreUserWithFriendsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserWithFriendsJoin>()
                .HasKey(u => new { u.UserId, u.FriendId});
            
            modelBuilder.Entity<UserWithFriendsJoin>()
                .HasOne(uwfj => uwfj.User)
                .WithMany(uwf => uwf.Friends)
                .HasForeignKey(uwfj => uwfj.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserWithFriendsJoin>()
                .HasOne(uwfj => uwfj.Friend)
                .WithMany()
                .HasForeignKey(uwfj => uwfj.FriendId);

        }
    }
}

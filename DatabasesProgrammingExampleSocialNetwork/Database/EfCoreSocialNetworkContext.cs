using DatabasesProgrammingExampleSocialNetwork.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExampleSocialNetwork.Database
{
    public class EfCoreSocialNetworkContext : DbContext
    {
        public EfCoreSocialNetworkContext(DbContextOptions<EfCoreSocialNetworkContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriendsJoin>()
                .HasKey(t => new { t.UserId, t.FriendId });

            modelBuilder.Entity<UserFriendsJoin>()
                .HasOne(pt => pt.User)
                .WithMany(p => p.Friends)
                .HasForeignKey(pt => pt.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserFriendsJoin>()
                .HasOne(pt => pt.Friend)
                .WithMany()
                .HasForeignKey(pt => pt.FriendId);

            modelBuilder.Entity<User>(u =>
            {
                u.OwnsMany(po => po.Posts, po =>
                {
                    po.ToTable("UserPosts");
                    po.WithOwner().HasForeignKey("UserId");
                    po.Property("UserId");
                    po.Property<int>("PostId")
                        .ValueGeneratedOnAdd();
                    po.HasKey("UserId", "PostId");
                    po.OwnsMany(p => p.Reactions, pr =>
                    {
                        pr.ToTable("UserPostReactions");
                        pr.WithOwner().HasForeignKey("UserId", "PostId");
                        pr.Property("PostId");
                        pr.Property<int>("ReactionId")
                            .ValueGeneratedOnAdd();
                        pr.HasKey("PostId", "ReactionId");
                    });
                    po.Navigation(po => po.Reactions).AutoInclude();
                });
                u.Navigation(po => po.Posts).AutoInclude();
            });
        }
    }
}
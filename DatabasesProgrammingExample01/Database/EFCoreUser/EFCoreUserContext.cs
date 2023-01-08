using DatabasesProgrammingExample01.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabasesProgrammingExample01.Database.EFCoreUser
{
    public class EFCoreUserContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public EFCoreUserContext(DbContextOptions<EFCoreUserContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasIndex(u => u.Email)
                    .IsUnique();
                e.Property(p => p.FirstName)
                    .HasColumnName("Vorname")
                    .HasMaxLength(200)
                    .IsRequired();
                e.HasKey(k => k.Id);
            });
        }
    }
}

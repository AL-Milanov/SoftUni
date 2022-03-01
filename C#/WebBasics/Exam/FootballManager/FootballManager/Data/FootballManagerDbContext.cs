namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<UserPlayer> UserPlayers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DatabaseConfiguration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username).IsUnique();
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email).IsUnique();

            modelBuilder.Entity<UserPlayer>()
                .HasKey(up => new { up.UserId, up.PlayerId });
        }
    }
}

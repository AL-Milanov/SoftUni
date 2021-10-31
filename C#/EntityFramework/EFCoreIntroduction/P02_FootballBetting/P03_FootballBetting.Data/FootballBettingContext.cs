using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions dbContext)
            : base(dbContext)
        {

        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=FootballBetting;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerStatistic>(e =>
            {
                e.HasKey(ps => new { ps.PlayerId, ps.GameId });
            });

            modelBuilder.Entity<Color>(e =>
            {
                e.HasMany(c => c.PrimaryKitTeams)
                 .WithOne(c => c.PrimaryKitColor)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(c => c.SecondaryKitTeams)
                 .WithOne(c => c.SecondaryKitColor)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Team>(e =>
            {
                e.HasMany(t => t.HomeGames)
                 .WithOne(t => t.HomeTeam)
                 .OnDelete(DeleteBehavior.Restrict);

                e.HasMany(t => t.AwayGames)
                 .WithOne(t => t.AwayTeam)
                 .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}

using Microsoft.EntityFrameworkCore;
using TeamPlayCRUD.Models;
namespace TeamPlayCRUD.Data
{
    public class TeamPlayerContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-9GQAA30\SQLEXPRESS;Initial Catalog=TeamPlayerDB;User ID=sa;Password=demo");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Config Player Entity Properties
            modelBuilder.Entity<Player>().HasKey(p => p.Id);
            modelBuilder.Entity<Player>().Property(p => p.FirstName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.LastName)
                .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Passport)
                  .HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Address)
                  .HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.Gender)
                  .HasMaxLength(10).IsRequired();

            //Config Team Entity Properties
            modelBuilder.Entity<Team>().HasKey(t => t.Id);
            modelBuilder.Entity<Team>().Property(t => t.Name)
               .HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.CountryCode)
               .HasMaxLength(3).IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.CreatedAt)
             .IsRequired();
            modelBuilder.Entity<Team>().Property(t => t.IsActive)
             .IsRequired();

            //Config State Entity Properties
            modelBuilder.Entity<State>().HasKey(s => s.Id);
            modelBuilder.Entity<State>().Property(s => s.Name)
               .HasMaxLength(13).IsRequired();
            modelBuilder.Entity<State>().Property(s => s.CreatedAt)
            .IsRequired();

            modelBuilder.Entity<Player>()
                .HasOne<State>(s => s.State)
                .WithMany(s=>s.Players)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s=>s.StateId)
                .HasConstraintName("Player_has_one_state");

            modelBuilder.Entity<Player>()
                 .HasOne<Team>(s => s.Team)
                 .WithMany(s => s.Players)
                 .OnDelete(DeleteBehavior.NoAction)
                 .HasForeignKey(s => s.TeamId)
                 .HasConstraintName("Player_has_one_team");

            modelBuilder.Entity<Team>().HasMany(t => t.Players)
                .WithOne(s => s.Team)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(s => s.TeamId)
                .HasConstraintName("team_has_many_player");
        }

    }
}
